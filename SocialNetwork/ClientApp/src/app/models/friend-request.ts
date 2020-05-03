import { User } from "./users";

export class FriendRequest {
  id: number;
  fromUserId: number;
  toUserId: number;
  date: string;
  appUser: User;
}
