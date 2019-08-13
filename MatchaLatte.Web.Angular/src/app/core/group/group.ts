import { Guid } from '../guid';
import { Store } from './store';

export class Group {
  id: Guid;
  startOn: Date;
  endOn: Date;
  createdOn: Date;
  store: Store;
}