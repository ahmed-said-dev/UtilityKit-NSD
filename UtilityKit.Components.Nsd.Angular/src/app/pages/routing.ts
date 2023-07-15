import { Routes } from '@angular/router';

const Routing: Routes = [
  {
    path: 'nsd',
    loadChildren: () => import('./nsd/nsd.module').then((m) => m.NsdModule),
    data: { layout: 'dark-header' },
  },
  {
    path: '',
    redirectTo: '/nsd/dashboard',
    pathMatch: 'full',
  },
  {
    path: '**',
    redirectTo: 'error/404',
  },
];

export { Routing };
