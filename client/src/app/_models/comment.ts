import { Member } from './member';
import { Post } from './post';

export interface Comment {

    id:number;
    content:string;
    createdTime:Date;
    appUser:Member;
    post:Post;

}