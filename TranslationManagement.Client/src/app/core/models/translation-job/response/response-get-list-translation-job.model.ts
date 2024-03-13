export interface ResponseGetListTranslationJobModel {
    items: GetListTranslationJobModelItem[];
}

export interface GetListTranslationJobModelItem {
    id: number;
    customerName: string;
    status: string;
    price: number;
}
