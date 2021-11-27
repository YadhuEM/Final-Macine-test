import { Role } from "./role";

export class User{
    Id:number;
    UserName:string;
    UserPassword:string;
    RoleId:number;
    Role:Role;
    isActive:boolean;
}