import { Large } from "./large";
import { Medium } from "./medium";
import { Small } from "./small";
import { Thumbnail } from "./thumbnail";

export interface Formats {
    thumbnail?: Thumbnail | undefined;
    large?: Large | undefined;
    small?: Small | undefined;
    medium?: Medium | undefined;
}