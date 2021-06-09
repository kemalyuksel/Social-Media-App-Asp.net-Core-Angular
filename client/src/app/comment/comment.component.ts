import { Component, Input, OnInit } from '@angular/core';
import { CommentModel } from '../_models/commentModel';
import { AccountService } from '../_services/account.service';
import { CommentService } from '../_services/comment.service';
import { ConfirmService } from '../_services/confirm.service';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent implements OnInit {

  @Input() id: number;
  commentList : CommentModel[];
  safeUrl :any;

  constructor(private commentService:CommentService,private confirmService:ConfirmService,public accountService: AccountService) { }

  ngOnInit(): void {
    this.loadComments();
  }

  loadComments(){
    this.commentService.getComment(this.id).subscribe(res => {
      this.commentList = res;
    })
  }

  deleteComment(id : number){
    this.confirmService.confirm('Confirm delete comment', 'This cannot be undone').subscribe(result => {
      if (result) {
        this.commentService.deleteComment(id).subscribe(() => {
          this.commentList.splice(this.commentList.findIndex(m => m.id === id), 1);
        })
      }
    })
  }

 

}
