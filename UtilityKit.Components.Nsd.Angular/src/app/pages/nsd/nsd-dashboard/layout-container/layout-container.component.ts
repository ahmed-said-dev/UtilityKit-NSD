import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { WidgetsListComponent } from './widgets-list/widgets-list.component';
import { ManageWidgetSettingsComponent } from './manage-widget-settings/manage-widget-settings.component';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs';
import { Dashboard, LayoutCell } from '../../../models/DashboardModel';
import { UpdateWidgetDataSourceComponent } from './update-widget-data-source/update-widget-data-source.component';
import { DashboardService } from 'src/app/pages/services/dashboard.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { WidgetService } from '../../widget/WidgetServies/widget.service';
import { WidgetModel } from '../../widget/WidgetModel/widget-model';
import { DrillDownChartService } from '../../../services/drill-down-chart.service';
import * as pdfMake from 'pdfmake/build/pdfmake';
import * as pdfFonts from 'pdfmake/build/vfs_fonts';
import 'bootstrap';
(pdfMake as any).vfs = pdfFonts.pdfMake.vfs;
interface DataItem {
  [key: string]: string | number;
  arg: any;
  val: any;
  AssetType: any;
  cityId: any;
};
const colors: string[] = ['#6babac', '#e55253'];


@Component({
  selector: 'app-layout-container',
  templateUrl: './layout-container.component.html',
  styleUrls: ['./layout-container.component.scss'],
})
export class LayoutContainerComponent implements OnInit {
  dashboard: Dashboard;
  dashboardId: any;
// Drill Down Chart Variables - Start -
  data: any[] = [];
  dataSource: any[] = [];
  isFirstLevel: boolean;
  colors: string[] = [];
  apiResponse: any;
  chartsDetails: any;
  datafilterDemo: DataItem[] = [];
  cityIds: any = [];
  filteredGovDataSource: any[] = [];
  showWidgets: boolean = false;
  govIds: any[] = [];
  dataDetailsFilter: any[] = [];
  originalData: DataItem[] = [];
  filterKeys: string[] = [];
  selectedObject: any;
  filterOptions: { [key: string]: string[] } = {};
  // Drill Down Chart Variables - End -


  constructor(
    private modalService: NgbModal,
    public route: ActivatedRoute,
    private spinnerService: NgxSpinnerService,
    private cdr: ChangeDetectorRef,
    private widgetService: WidgetService,
    private dashboardService: DashboardService,
    private service: DrillDownChartService 
  ) {
    this.service = service;
    this.isFirstLevel = true;
    this.extractFilterKeys();
    this.extractFilterOptions();
  }

  ngOnInit(): void {
    this.route.paramMap
      .pipe(map(() => window.history.state))
      .subscribe((res) => {
        delete res.navigationId;
        if (res.id) this.dashboard = res;
      });

    this.extractDashboardId();
    this.getDashboard();
    // ngOnInit DrillDown Functions -Start-
    this.service.getTransformedData().subscribe((response) => {
      this.apiResponse = response;

      this.PlotChart(response);
      this.colors = this.getColors();
    });

    this.service.getChartsDetails().subscribe((response) => {
      this.chartsDetails = response;
      this.PlotChartDetails(response);
      this.dataSource = this.filterData('');
      this.colors = this.getColors();
    });
    // ngOnInit DrillDown Functions -End-

  }

  assignCells() {
    this.dashboard.layoutCells?.forEach((layoutCell) => {
      let element = document.getElementById(layoutCell.cellsDefinition);
      if (!layoutCell.widgetId) {
        element?.children[1].classList.add('d-none');
        element?.children[0].classList.remove('d-none');
      } else {
        element?.children[0].classList.add('d-none');
        element?.children[1].classList.remove('d-none');
        element!.children[1].querySelector('h1')!.innerText =
          layoutCell.widget!.name;

        element!.children[1].querySelector(
          'img'
        )!.src = `./assets/media/WidgetThumbnails/${layoutCell.widget?.thumbnail}`;
      }
    });
  }

  extractDashboardId() {
    this.dashboardId = this.route.snapshot.paramMap.get('id');
  }

  getDashboard() {
    this.spinnerService.show();
    this.dashboardService.Get(this.dashboardId).subscribe((res: Dashboard) => {
      this.dashboard = res;
      //this.cdr.detectChanges();
      this.spinnerService.hide();
      this.assignCells();
    });
  }

  openWidgetsList(name: string) {
    var cell = this.dashboard.layoutCells?.find(
      (x) => x.cellsDefinition === name
    );
    var widgetListModal = this.modalService.open(WidgetsListComponent, {
      size: 'lg',
    });
    widgetListModal.componentInstance.cell = cell;

    widgetListModal.result.then((val) => {
      if (val) {
        this.getDashboard();
      }
    });
  }

  openWidgetsSettings() {
    this.modalService.open(ManageWidgetSettingsComponent);
  }
  openUpdateDataSource() {
    this.modalService.open(UpdateWidgetDataSourceComponent);
  }

  // Drilldown Chart Functions -Start-
  filterGovDataSource(event: any) {
    const selectedGovId = event.target.value;
    let filteredGovDataSource = this.dataDetailsFilter.filter(
      (item) => item.govId === selectedGovId
    );
    this.dataSource = filteredGovDataSource;
  }

  filterData(name: string): DataItem[] {
    this.data = this.data.filter((item) => item.AssetType == name);
    return this.data;
  }

  getColors(): string[] {
    return colors;
  }

  private extractFilterKeys(): void {
    const uniqueKeys = new Set<string>();

    for (const item of this.originalData) {
      const keys = Object.keys(item);
      keys.forEach((key) => uniqueKeys.add(key));
    }

    this.filterKeys = Array.from(uniqueKeys);
  }

  private extractFilterOptions(): void {
    for (const key of this.filterKeys) {
      const options = new Set<string>();

      for (const item of this.originalData) {
        options.add(String(item[key]));
      }

      this.filterOptions[key] = Array.from(options);
    }
  }

  filterDataSource(event: any, key: string): void {
    const selectedValue = event.target.value;
    this.dataSource = this.originalData.filter(
      (item) => item[key] === selectedValue
    );
  }

  onButtonClick() {
    if (!this.isFirstLevel) {
      this.isFirstLevel = true;
      this.dataSource = this.filterData('');
      this.showWidgets = false;
    }
  }

  onPointClick(e: any) {
    if (this.isFirstLevel) {
      this.showWidgets = true;
      this.isFirstLevel = false;
      this.dataSource = this.datafilterDemo.filter(
        (item) => item.AssetType == e.target.originalArgument
      );
      this.originalData = this.dataSource;
      this.extractFilterKeys();
      this.extractFilterOptions();
      this.dataDetailsFilter = this.dataSource;
      this.cityIds = [...new Set(this.dataSource.map((item) => item.cityId))];
      this.govIds = [...new Set(this.dataSource.map((item) => item.govId))];
    }
  }

  customizePoint = () => {
    let pointSettings: any;

    pointSettings = {
      color: this.colors[Number(this.isFirstLevel)],
    };

    if (!this.isFirstLevel) {
      pointSettings.hoverStyle = {
        hatching: 'none',
      };
    }

    return pointSettings;
  };

  displayObject(obj: any) {
    this.selectedObject = obj;
  }

  PlotChart(res: any) {
    for (let i = 0; i < res.length; i++) {
      let tmp = {
        arg: res[i].arg,
        val: res[i].val,
        AssetType: '',
      };
      this.data.push(tmp);
    }
  }

  PlotChartDetails(res: any) {
    for (let i = 0; i < res.length; i++) {
      let tmpDetails = {
        arg: res[i].assetType,
        val: res[i].totalLength,
        AssetType: `${res[i].assetGroup} KV`,
        cityId: res[i].cityId,
        govId: res[i].govId,
      };
      this.data.push(tmpDetails);
    }
    this.datafilterDemo = this.data;
  }

  exportPdf() {
    const tableData: any[][] = [];
    const tableHeaders: string[] = Object.keys(this.chartsDetails[0]);
    const idIndex = tableHeaders.indexOf('id');

    const capitalizeFirstChar = (str: string) => {
      return str.charAt(0).toUpperCase() + str.slice(1);
    };

    const addSpacesBeforeCapitalLetters = (str: string) => {
      return str.replace(/([A-Z])/g, ' $1');
    };

    const formatHeader = (header: string) => {
      let formattedHeader = capitalizeFirstChar(header);
      formattedHeader = addSpacesBeforeCapitalLetters(formattedHeader);
      return formattedHeader;
    };

    const formattedHeaders = tableHeaders
      .filter((header: string, index: number) => index !== idIndex)
      .map((header: string) => formatHeader(header));

    this.chartsDetails.forEach((item: any) => {
      const rowData: any[] = [];
      tableHeaders.forEach((header: string, index: number) => {
        if (index !== idIndex) {
          rowData.push(item[header]);
        }
      });
      tableData.push(rowData);
    });

    const documentDefinition = {
      content: [
        {
          table: {
            headerRows: 1,
            body: [
              formattedHeaders.map((header) => ({
                text: header,
                fillColor: '#0d3678',
                color: 'white',
                bold: true,
              })),
              ...tableData,
            ],
          },
        },
      ],
    };

    pdfMake.createPdf(documentDefinition).download('Data Table.pdf');
  }

  exportCsv() {
    const tableData: any[][] = [];
    const tableHeaders: string[] = Object.keys(this.chartsDetails[0]);
    const idIndex = tableHeaders.indexOf('id');

    const capitalizeFirstChar = (str: string) => {
      return str.charAt(0).toUpperCase() + str.slice(1);
    };

    const addSpacesBeforeCapitalLetters = (str: string) => {
      return str.replace(/([A-Z])/g, ' $1');
    };

    const formatHeader = (header: string) => {
      let formattedHeader = capitalizeFirstChar(header);
      formattedHeader = addSpacesBeforeCapitalLetters(formattedHeader);
      return formattedHeader;
    };

    const formattedHeaders = tableHeaders
      .filter((header: string, index: number) => index !== idIndex)
      .map((header: string) => formatHeader(header));

    this.chartsDetails.forEach((item: any) => {
      const rowData: any[] = [];
      tableHeaders.forEach((header: string, index: number) => {
        if (index !== idIndex) {
          rowData.push(item[header]);
        }
      });
      tableData.push(rowData);
    });
    let csvContent = formattedHeaders.join(',') + '\n';
    tableData.forEach((rowData: any[]) => {
      csvContent += rowData.join(',') + '\n';
    });
    const link = document.createElement('a');
    const csvBlob = new Blob([csvContent], { type: 'text/csv;charset=utf-8;' });
    const csvUrl = URL.createObjectURL(csvBlob);
    link.setAttribute('href', csvUrl);
    link.setAttribute('download', 'Data Table.csv');
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
  }

  // Drilldown Chart Functions -End-

}
