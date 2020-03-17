import { Table } from './Table';
import { Product } from './Product';

export interface Order {
  id: number;
  tableId: number;
  table: Table;
  clientName: string;
  clientCpf: string;
  date: Date;
  status: string;
  price: number;
  Products: Product[];
}
