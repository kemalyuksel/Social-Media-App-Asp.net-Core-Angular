import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CommentAddModel } from '../_models/commentAddModel';
import { CommentModel } from '../_models/commentModel';
import { Post } from '../_models/post';
import { PostModel } from '../_models/PostModel';
import { CommentService } from '../_services/comment.service';
import { PostService } from '../_services/post.service';

@Component({
  selector: 'app-add-comment',
  templateUrl: './add-comment.component.html',
  styleUrls: ['./add-comment.component.css']
})
export class AddCommentComponent implements OnInit {
  
  @Input() id: number;
  commentList : CommentModel[];
  commentModel = new CommentAddModel();

  constructor(private commentService:CommentService) { }

  ngOnInit(): void {
    
  }
  
  addComment(){
    this.commentService.addComment(this.commentModel,this.id)
    .subscribe(data => {
      console.log(data),
      window.location.reload();
    } );
  }


}
