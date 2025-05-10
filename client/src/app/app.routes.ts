import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './members/member-list.component';
import { MemberDetailComponent } from './members/member-detail.component';
import { UsersListComponent } from './explore/users-list.component';
import { MessagesComponent } from './social/messages.component';
import { authGuard } from './accounts/auth.guard';
import { NotFoundComponent } from './commons/error/not-found.component';
import { ServerErrorComponent } from './commons/error/server-error.component';

export const routes: Routes = [
    { path: '', component: HomeComponent },
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [authGuard],
        children: [
            { path: 'members', component: MemberListComponent },
            { path: 'members/:id', component: MemberDetailComponent },
            { path: 'explore', component: UsersListComponent },
            { path: 'social/messages', component: MessagesComponent },
        ],
    },
    { path: 'not-found', component: NotFoundComponent },
    { path: 'server-error', component: ServerErrorComponent },
    { path: "**", component: HomeComponent, pathMatch: 'full' },
];
