import { Hipervinculo } from "./hipervinculo";
import { sesionUsuario } from "./sesionUsuario";

export class Sesion{
    Clase?: number;
    FechaSesion?: string;
    Password?: string = "123";
    CodigoSesion?: string = "123";
    mdHipervinculos?: Hipervinculo[];
    MdSesionUsuarios?: sesionUsuario[];
}