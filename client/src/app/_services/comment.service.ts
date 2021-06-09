import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CommentAddModel } from '../_models/commentAddModel';
import { CommentModel } from '../_models/commentModel';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getComment(id:number){
    return this.http.get<CommentModel[]>(this.baseUrl + 'comments/'+id);
   }
   
   deleteComment(id: number){
     return this.http.delete(this.baseUrl + 'comments/' + id);
   }

   addComment(model : CommentAddModel,id:number) {
    console.log("id:" +id );
    return this.http.post(this.baseUrl + 'comments/' + id ,model);
  }

}
