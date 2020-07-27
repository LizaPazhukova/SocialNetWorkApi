import { User } from "./users";

export class Message {
  Id: number;
  fromUserId: number;
  toUserId: number;
  body: string;
  isReaded: boolean;
  Date: number;
  fromUser: User;
  toUser: User;
}
