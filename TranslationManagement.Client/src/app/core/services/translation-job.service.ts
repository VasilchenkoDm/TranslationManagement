import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ApiEndpointHelper } from "../helpers/api-endpoint.helper";
import { RequestAssignTranslationJobModel, RequestCreateTranslationJobModel, RequestCreateWithFileTranslationJobModel, ResponseGetListTranslationJobModel } from "../models/translation-job";
import { ApiEndpointsConstants } from "../constants";

@Injectable({
    providedIn: 'root'
})
export class TranslationJobService {
    constructor(private httpClient: HttpClient) {
    }

    getJobs(): Observable<ResponseGetListTranslationJobModel> {
        return this.httpClient.get<ResponseGetListTranslationJobModel>(ApiEndpointHelper.get(ApiEndpointsConstants.TRANSLATION_JOB_GET_JOBS));
    }

    create(model: RequestCreateTranslationJobModel): Observable<any> {
        return this.httpClient.post(
            ApiEndpointHelper.get(ApiEndpointsConstants.TRANSLATION_JOB_CREATE), model
        );
    }

    createWithFile(model: RequestCreateWithFileTranslationJobModel): Observable<any> {        
        const formData = this.getFormData(model);
        return this.httpClient.post(
            ApiEndpointHelper.get(ApiEndpointsConstants.TRANSLATION_JOB_CREATE_WITH_FILE), formData
        );
    }

    assign(model: RequestAssignTranslationJobModel): Observable<any> {
        return this.httpClient.post(
            ApiEndpointHelper.get(ApiEndpointsConstants.TRANSLATION_JOB_ASSIGN), model
        );
    }

    private getFormData(model: any): FormData {
        const formData = new FormData();
        Object.keys(model).forEach((item: string) => {
            const value = model[item];
            const prop = item;
            formData.append(prop, value);
        });
        return formData;
    }

}