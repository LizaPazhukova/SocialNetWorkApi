import { Like } from "./like";
import { Comment } from "./comment";
import { User } from "./users";

export class Post {
  constructor(public text: string) { }
  id: number;
  date: number;
  likes: Like[];
  comments: Comment[];
  appUserId: number;
  appUser: User;
}
