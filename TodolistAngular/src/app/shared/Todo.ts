import { Tag } from "./Tag";

export class Todo{
    id: number;
    name: string;
    description: string;
    date: any;
    isDone: boolean;
    tags: Tag[];
}