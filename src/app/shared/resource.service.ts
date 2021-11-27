import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Resource } from './resource';
@Injectable({
  providedIn: 'root'
})
export class ResourceService {

  //create an instance of resource
  formData: Resource = new Resource();
  resources: Resource[];
  resourceId:number;

  constructor(private httpClient: HttpClient) { }

  //insert resource
  insertRequest(resources: Resource): Observable<any> {
    return this.httpClient.post(environment.apiUrl + "/api/request/addrequest", resources)
  }

  //update resource
  updateRequest(resources: Resource): Observable<any> {
    return this.httpClient.put(environment.apiUrl + "/api/request/updaterequest", resources)
  }

  //get all resources
  bindListRequest() {
    this.httpClient.get(environment.apiUrl + "/api/request/getrequests")
      .toPromise().then(response =>
        this.resources = response as Resource[]
      );
     }
    //get resource by Id

    getRequest(resourceId: number) : Observable < any > 
    {
      return this.httpClient.get(environment.apiUrl + "");
    }
  
}
