/*
import { Image1 } from "./scratchCardImages/image1";
import { Image2 } from "./scratchCardImages/image2";
import { Image3 } from "./scratchCardImages/image3";
import { Image4 } from "./scratchCardImages/image4";
import { Image5 } from "./scratchCardImages/image5";
*/
import { BackgroundImage } from "./scratchCardImages/backgroundImage";
import { LosingImage } from "./scratchCardImages/losingImage";
import { TileImage } from "./scratchCardImages/tileImage";
import { WinningImage } from "./scratchCardImages/winningImage";

export interface ScratchCardStrapi {
    id: number;
    title?: string | undefined;
    startDate?: Date | undefined;
    endDate?: Date | undefined;
    order?: number | undefined;
    created_At: Date;
    updated_At: Date;
    /*
    image1?: Image1 | undefined;
    image2?: Image2 | undefined;
    image3?: Image3 | undefined;
    image4?: Image4 | undefined;
    image5?: Image5 | undefined;
    */
    tileImage?: TileImage | undefined;
    losingImage?: LosingImage | undefined;
    winningImage?: WinningImage | undefined;
    backgroundImage?: BackgroundImage | undefined;
}