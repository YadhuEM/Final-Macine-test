import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { ResourceService } from 'src/app/shared/resource.service';
import { Resource } from 'src/app/shared/resource';
@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.css']
})
export class PostListComponent implements OnInit {
  page: number = 1;
  filter: string;
  constructor(public resourceService: ResourceService, private toastrService: ToastrService, private router: Router) { }

  ngOnInit(): void {

    this.resourceService.bindListRequest();
  }

  //populate form by clicking the column fields
  populateForm(resource: Resource) {
    console.log(resource);

    /*//date format
    var datePipe=new DatePipe("en-UK");
    let formatedDate:any=datePipe.transform(post.CreatedDate,'yyyy-MM-dd');
    resource.CreatedDate=formatedDate;
    this.resourceService.formData=Object.assign({},resource);*/
  }

  deleteRequest(emp: Resource) {
    console.log(emp);
    //console.log(emp.resourceName);
    var value = confirm("Are you sure to delete   ?")
    if (value) {
      console.log("Deleting a record!!");
      emp.isActive = false;
      console.log(emp);
      this.resourceService.updateRequest(emp).subscribe(
        (result) => {
          console.log(result);
          this.resourceService.bindListRequest();
        });
      this.toastrService.warning( " deleted!", 'EmpApp');
    }
    else {
      //this.toastrService.info("Employee " + id + " deleted!", 'EmpApp');
    }
  }

  //update a resource
  updateRequest(requestId: number) {
    console.log("Request id is" +requestId);
    this.router.navigate(['post', requestId])

  }
}
