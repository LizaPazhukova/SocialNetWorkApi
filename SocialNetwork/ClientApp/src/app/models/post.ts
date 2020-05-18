import { Like } from "./like";
import { Comment } from "./comment";

export class Post {
  constructor(public text: string) { }
  id: number;
  date: number;
  likes: Like[];
  comments: Comment[];
}
