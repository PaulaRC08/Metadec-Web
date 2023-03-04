export class Hipervinculo{
    NombreHipervinculo?: string;
    UrlHpervinculo?: string;
    TipoHipervinculo?: string;

    constructor(nh: string, uh: string, th: string){
        this.NombreHipervinculo = nh;
        this.UrlHpervinculo = uh;
        this.TipoHipervinculo = th;
    }
}