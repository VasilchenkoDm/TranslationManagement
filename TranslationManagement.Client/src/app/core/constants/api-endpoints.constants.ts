export class ApiEndpointsConstants {
  /*----------------TranslationJob-------------------*/
  public static get TRANSLATION_JOB_GET_JOBS(): string { return 'translationJob/getJobs'; }
  public static get TRANSLATION_JOB_CREATE(): string { return 'translationJob/createJob'; }
  public static get TRANSLATION_JOB_ASSIGN(): string { return 'translationJob/assignJob'; }
    /*----------------TranslatorManagement-------------------*/
    public static get TRANSLATOR_GET_TRANSLATORS_BY_STATUS(): string { return 'translatorManagement/GetTranslatorsByStatus'; }
}