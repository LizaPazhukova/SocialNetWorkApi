import { Like } from "./like";

export class Post {
  constructor(public text: string) { }
  id: number;
  date: number;
  likes: Like[];
}
