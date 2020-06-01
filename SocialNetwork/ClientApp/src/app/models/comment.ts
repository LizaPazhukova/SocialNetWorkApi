import { User } from "./users";

export class Comment {
  id: number;
  date: number;
  text: string;
  postId: number;
  appUserId: number;
  appUser: User;
}
