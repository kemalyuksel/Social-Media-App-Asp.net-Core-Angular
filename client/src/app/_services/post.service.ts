import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Post } from '../_models/post';
import { PostModel } from '../_models/postModel';

@Injectable({
  providedIn: 'root'
})

export class PostService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}
   
   getPosts(){
    return this.http.get<Post[]>(this.baseUrl + 'posts/');
   }
   
   deletePost(id: number){
     return this.http.delete(this.baseUrl + 'posts/' + id);
   }

   getPostsByUsername(username : string){
    return this.http.get<Post[]>(this.baseUrl + 'posts/'+ username);
   }

   addPost(model : PostModel) {
    return this.http.post(this.baseUrl + 'posts/' ,model);
  }


}
