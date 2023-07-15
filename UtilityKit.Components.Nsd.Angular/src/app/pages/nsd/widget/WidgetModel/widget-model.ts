export class WidgetModel {
  id:string;
  name: string;
  description: string;
  thumbnail: string;
  widgetFileSource?: string;
  industries: Industry[];
  minCellSize: number;
  isBuiltIn: boolean;
  creationDate: Date;
  lastModifiedDate: Date;
  createdBy: string;
  lastModifiedBy: string;
  configurationDefinitions: ConfigurationDefinitionItem[];
}
export enum Industry {
  electricity = 1,
  water = 2,
  gas = 3,
  sewer = 4,
  telecom = 5,
}

enum ConfigType {
  text = 1,
  list = 2,
}
export class ConfigurationDefinitionItem {
  key: string;
  value: string;
  type: ConfigType;
  options: string[];
  defaultValue: string;
}
