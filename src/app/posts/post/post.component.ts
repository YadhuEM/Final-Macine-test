import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Post } from 'src/app/shared/post';
import { ActivatedRoute, Router } from '@angular/router';
import { ResourceService } from 'src/app/shared/resource.service';
import { Resource } from 'src/app/shared/resource';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {

  postId: number;
  post: Resource = new Resource();
  constructor(private toastrService: ToastrService,
    private router: Router, public resourceService: ResourceService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {

     //get empId from activated route
    this.postId = this.route.snapshot.params['requestId'];
    this.resetform();
    this.resourceService.bindListRequest();

    if(this.postId !=0 || this.postId !=null){
      //getEmployee
    this.resourceService.getRequest(this.postId).subscribe(
      (data: any): void => {
        console.log(data);
      },
      error =>
      console.log(error)
    );

    }

  }

  onSubmit(form: NgForm)
  {
    console.log(form.value);
    let addId =this.resourceService.formData.requestId;
    
     if(addId==0||addId==null){
        //insert
       this.insertRecord(form);
     }
     else
     {
       //update
       console.log("update")
       this.updateRecord(form);
     }
   
   }
 
   //reset/clear all content from form  at initialization
   resetform(form?:NgForm){
     if(form!=null){
       form.resetForm();
 
     }
 
   }
 
 
   //insert
   insertRecord(form?:NgForm){
     console.log("inserting a record...");
     this.resourceService.insertRequest(form.value).subscribe
     ((result)=>
     {
       console.log(result);
       this.resetform(form);
       this.toastrService.success(' record has been inserted','Travel App');
      
     }
     );
     //window.alert("Post record has been inserted");
     //window.location.reload();
   }
 
   
   
   //update
   updateRecord(form?:NgForm)
   {
     console.log("updating a record...");
     this.resourceService.updateRequest(form.value).subscribe
     ((result)=>
     {
       console.log(result);
       this.resetform(form);
       this.toastrService.success('record has been updated','Travel App');
      //this.resourceService.bindListPost();
     }
     );
     
     //window.alert("Post record has been updated");
     window.location.reload();
 
   
}


}  
