import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { ManagerComponent } from './manager/manager.component';
import { PostListComponent } from './posts/post-list/post-list.component';
import { PostComponent } from './posts/post/post.component';
import { PostsComponent } from './posts/posts.component';
import {AuthGuard} from './shared/auth.guard';

const routes: Routes = [

  {path:'', redirectTo:"/login",pathMatch: 'full'},
  {path:'posts',component:PostsComponent},
  {path:'post', component: PostComponent},
  {path:'postlist',component: PostListComponent},
  {path:'post/:postId', component: PostComponent},
  {path:'postlist/post',component: PostComponent},
  {path:'home', component: HomeComponent},
  {path:'login', component: LoginComponent},
  {path:'admin', component: AdminComponent, canActivate:[AuthGuard],data:{role:'1'}},
  {path:'manager', component: ManagerComponent,canActivate:[AuthGuard],data:{role:'2'}},


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
