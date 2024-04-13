import { Role } from "../constants/role";

export class User {
  id!: string;
  name!: string;
  email!: string;
  role!: Role;
}