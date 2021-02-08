import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LogsComponent } from './logs/logs.component';
import { LogsDetailsComponent } from './logs-details/logs-details.component';
import { ImportLogsComponent } from './import-logs/import-logs.component';
import { AddLogsComponent } from './add-logs/add-logs.component';
import { EditLogsComponent } from './edit-logs/edit-logs.component';

const routes: Routes = [
  {
    path: 'logs',
    component: LogsComponent,
    data: { title: 'List of Logs' }
  },
  {
    path: 'logs-details/:id',
    component: LogsDetailsComponent,
    data: { title: 'Logs Details' }
  },
  {
    path: 'logs-import',
    component: ImportLogsComponent,
    data: { title: 'Logs Import' }
  },
  {
    path: 'add-logs',
    component: AddLogsComponent,
    data: { title: 'Add Logs' }
  },
  {
    path: 'edit-logs/:id',
    component: EditLogsComponent,
    data: { title: 'Edit Logs' }
  },
  { path: '',
    redirectTo: '/logs',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
