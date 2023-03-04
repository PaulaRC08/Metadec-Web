import { DOCUMENT } from '@angular/common';
import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { UsuarioService } from '../../../../app/services/usuario.service';
import { User } from '../../../../app/models/usuario';

function hello(){
  
  const subdomain = 'demo'; // Replace with your custom subdomain
  const frame = document.getElementById('frame') as HTMLIFrameElement;
  
  frame.src = `https://${subdomain}.readyplayer.me/avatar?frameApi&clearCache&bodyType=fullbody`;
  
  window.addEventListener('message', subscribe);
  document.addEventListener('message', subscribe);
  
  function subscribe(event: any) {
      const json = parse(event);
  
      if (json?.source !== 'readyplayerme') {
          return;
      }
  
      // Susbribe to all events sent from Ready Player Me once frame is ready
      if (json.eventName === 'v1.frame.ready') {

        if(frame.contentWindow){
          frame.contentWindow.postMessage(
            JSON.stringify({
                target: 'readyplayerme',
                type: 'subscribe',
                eventName: 'v1.**'
            }),
            '*'
        );
        }
      }
  
      // Get avatar GLB URL
      if (json.eventName === 'v1.avatar.exported') {
          console.log(`Avatar URL: ${json.data.url}`);
          localStorage.setItem("urlAvatar", json.data.url);
          //(document.getElementById('avatarcreado') as HTMLElement).hidden = false;
          //(document.getElementById('avatarUrl') as HTMLInputElement).value= json.data.url;
          //(document.getElementById('frame') as HTMLIFrameElement).hidden = true;
      }
  
      // Get user id
      if (json.eventName === 'v1.user.set') {
          console.log(`User with id ${json.data.id} set: ${JSON.stringify(json)}`);
      }
  }
  
  function parse(event: any) {
      try {
          return JSON.parse(event.data);
      } catch (error) {
          return null;
      }
  }
  
  function displayIframe() {
      (document.getElementById('frame') as HTMLIFrameElement).hidden = false;
  }
}

@Component({
  selector: 'app-avatar',
  templateUrl: './avatar.component.html',
  styleUrls: ['./avatar.component.scss']
})
export class AvatarComponent {

  usuario?: User;

  constructor(private _formBuilder: FormBuilder,
              private usuarioService: UsuarioService,
              private snackBar: MatSnackBar,
              private route: ActivatedRoute,
              private router:Router) { }

  ngOnInit(): void{
    localStorage.removeItem("urlAvatar")
    hello();
    window.console.log = () => {}
  }
  ngDoCheck(){
    console.log(localStorage.getItem("urlAvatar"));
    if(localStorage.getItem("urlAvatar") != null){
      console.log("Se logro");
      this.usuarioService.urlUser =localStorage.getItem("urlAvatar")!;
      localStorage.removeItem("urlAvatar");
      this.router.navigate(['/inicio/register'])
      window.console.log = () => {}
    }
  }


}

