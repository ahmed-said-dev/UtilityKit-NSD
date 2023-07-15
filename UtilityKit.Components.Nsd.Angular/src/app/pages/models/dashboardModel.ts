import { WidgetModel } from '../nsd/widget/WidgetModel/widget-model';

export class Dashboard {
  id: string;
  name: string;
  description?: string | undefined;
  creationDate: any;
  lastModifiedDate: any;
  dataSourceId: string;
  layoutId: string;
  tags?: string | undefined;
  createdBy?: string | undefined;
  lastModifiedBy?: string | undefined;
  layoutCells?: LayoutCell[];
}
export class LayoutCell {
  id: string;
  cellSize: any;
  widgetId?: string | undefined;
  widget?: WidgetModel | undefined;
  dashboardId?: string | undefined;
  cellsDefinition: string;
}
