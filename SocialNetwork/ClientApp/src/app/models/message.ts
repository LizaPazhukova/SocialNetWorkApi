import { User } from "./users";

export class Message {
  Id: number;
  fromUserId: number;
  toUserId: number;
  body: string;
  Date: number;
  appUser: User;
}
