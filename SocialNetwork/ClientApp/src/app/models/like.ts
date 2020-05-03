import { User } from "./users";
import { Post } from "./post";

export class Like {
  id: number;
  userId: number;
  postId: number;
  date: string;
  appUser: User;
  post: Post;
}
