import { Comment } from './comment';
import { User } from './user';

export interface Post {
    id: number;
    content:string;
    createdTime:Date;
    mediaUrl:string;
    comments:Comment[];
    appUser:User;

}