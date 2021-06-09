import { User } from './user';

export class PostModel {
    id: number;
    content:string;
    createdTime:Date;
    mediaUrl:string;
    appUser:User;
}