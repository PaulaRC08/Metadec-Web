export class User{
    Usuario?: string;
    TipoUsuario?: string;
    Pasword?: string;
    AvatarUrl?: string;
    Nombres?: string;
    Apellidos?: string;
    Sexo?: string;
    Correo?: string;
    TratamientoDatos?: boolean;
    Administrador?: boolean = false;
    IdPais?: number;
}