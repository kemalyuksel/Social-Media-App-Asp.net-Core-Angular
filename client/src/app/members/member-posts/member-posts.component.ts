import {Component, Input, OnInit, ViewChild } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Post } from 'src/app/_models/post';
import { PostModel } from 'src/app/_models/PostModel';
import { AccountService } from 'src/app/_services/account.service';
import { ConfirmService } from 'src/app/_services/confirm.service';
import { PostService } from 'src/app/_services/post.service';

@Component({
  selector: 'app-member-posts',
  templateUrl: './member-posts.component.html',
  styleUrls: ['./member-posts.component.css']
})
export class MemberPostsComponent implements OnInit {

  @Input() username: string;
  postList :Post[];
  postModel = new PostModel();
  safeUrl :any;


  constructor(private postService:PostService,private sanitizer: DomSanitizer,private confirmService:ConfirmService,public accountService: AccountService) { }

  ngOnInit(): void {
    this.loadPosts();
  }

  loadPosts(){
    this.postService.getPostsByUsername(this.username).subscribe(res => {
      this.postList = res;
    })
  }

  deletePost(id : number){
    this.confirmService.confirm('Confirm delete post', 'This cannot be undone').subscribe(result => {
      if (result) {
        this.postService.deletePost(id).subscribe(() => {
          this.postList.splice(this.postList.findIndex(m => m.id === id), 1);
        })
      }
    })
  }

  transform(url) {
    return this.sanitizer.bypassSecurityTrustResourceUrl(url);
  }

  addPost(){
    this.postService.addPost(this.postModel)
    .subscribe(data => {
      console.log(data)
      this.loadPosts();
    })
  }


}
