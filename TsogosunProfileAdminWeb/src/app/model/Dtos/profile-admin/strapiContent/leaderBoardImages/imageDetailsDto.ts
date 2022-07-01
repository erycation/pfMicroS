export interface ImageDetailsDto {
    id: number;
    name?: string | undefined;
    alternativeText?: string | undefined;
    caption?: string | undefined;
    width: number;
    height: number;
    hash?: string | undefined;
    ext?: string | undefined;
    mime?: string | undefined;
    size: number;
    url?: string | undefined;
    previewUrl?: string | undefined;
    provider?: string | undefined;
    provider_Metadata?: string | undefined;
    created_At: Date;
    updated_At: Date;
}