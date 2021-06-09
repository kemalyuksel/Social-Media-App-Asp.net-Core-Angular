import { CommentUser } from './commentUser';

export interface CommentModel {

    id:number;
    content:string;
    createdTime:Date;
    appUser:CommentUser;

}







