import { Large } from "./large";
import { Medium } from "./medium";
import { Small } from "./small";
import { Thumbnail } from "./thumbnail";

export interface Formats {
    large?: Large | undefined;
    small?: Small | undefined;
    medium?: Medium | undefined;
    thumbnail?: Thumbnail | undefined;
}