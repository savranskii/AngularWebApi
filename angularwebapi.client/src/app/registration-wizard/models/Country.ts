import { Province } from "./Province";

export interface Country {
	name: string;
	value: string;
	provinces: Province[];
}