import { Item } from './item-model';

export interface Column {
  header: string;
  wipLimit: number;
  wipLimitExceeded: boolean;
  items: Item[]
}
