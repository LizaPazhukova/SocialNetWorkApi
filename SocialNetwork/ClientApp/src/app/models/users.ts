export class User {
  id: number;
  firstName: string;
  lastName: string;
  fullName: string;
  avatar: number[];
  city: string;
  birthDate: number;
  gender: Gender;
  phoneNumber: string;
  friends: User[];
}
export enum Gender {
  Male,
  Female
}
