import { Member } from './member';
import { Post } from './post';

export class CommentAddModel {

    id:number;
    content:string;
    createdTime:Date;
    appUser:Member;
    post:Post;

}