using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Threading;

namespace USAspendingWindow
{
    public enum Combobox
    {
        AGENCY,
        FISCAL_YEAR
    }
    class Utility
    {

        public static String USAspendRecordtoCSV(ObservableCollection<OutOfScope_usaspend> records)
        {

            StringBuilder csvrecords = new StringBuilder();

            StringBuilder heading = new StringBuilder();
            heading.Append("unique_transaction_id," +
                            "transaction_status," +
                            "dollarsobligated," +
                            "baseandexercisedoptionsvalue," +
                            "baseandalloptionsvalue," +
                            "maj_agency_cat," +
                            "mod_agency," +
                            "maj_fund_agency_cat," +
                            "contractingofficeagencyid," +
                            "contractingofficeid," +
                            "fundingrequestingagencyid," +
                            "fundingrequestingofficeid," +
                            "fundedbyforeignentity," +
                            "signeddate," +
                            "effectivedate," +
                            "currentcompletiondate," +
                            "ultimatecompletiondate," +
                            "lastdatetoorder," +
                            "contractactiontype," +
                            "reasonformodification," +
                            "typeofcontractpricing," +
                            "priceevaluationpercentdifference," +
                            "subcontractplan," +
                            "lettercontract," +
                            "multiyearcontract," +
                            "performancebasedservicecontract," +
                            "majorprogramcode," +
                            "contingencyhumanitarianpeacekeepingoperation," +
                            "contractfinancing," +
                            "costorpricingdata," +
                            "costaccountingstandardsclause," +
                            "descriptionofcontractrequirement," +
                            "purchasecardaspaymentmethod," +
                            "numberofactions," +
                            "nationalinterestactioncode," +
                            "progsourceagency," +
                            "progsourceaccount," +
                            "progsourcesubacct," +
                            "account_title," +
                            "rec_flag," +
                            "typeofidc," +
                            "multipleorsingleawardidc," +
                            "programacronym," +
                            "vendorname," +
                            "vendoralternatename," +
                            "vendorlegalorganizationname," +
                            "vendordoingasbusinessname," +
                            "divisionname," +
                            "divisionnumberorofficecode," +
                            "vendorenabled," +
                            "vendorlocationdisableflag," +
                            "ccrexception," +
                            "streetaddress," +
                            "streetaddress2," +
                            "streetaddress3," +
                            "city," +
                            "state," +
                            "zipcode," +
                            "vendorcountrycode," +
                            "vendor_state_code," +
                            "vendor_cd," +
                            "congressionaldistrict," +
                            "vendorsitecode," +
                            "vendoralternatesitecode," +
                            "dunsnumber," +
                            "parentdunsnumber," +
                            "phoneno," +
                            "faxno," +
                            "registrationdate," +
                            "renewaldate," +
                            "mod_parent," +
                            "locationcode," +
                            "statecode," +
                            "placeofperformancecity," +
                            "pop_state_code," +
                            "placeofperformancecountrycode," +
                            "placeofperformancezipcode," +
                            "pop_cd," +
                            "placeofperformancecongressionaldistrict," +
                            "psc_cat," +
                            "productorservicecode," +
                            "systemequipmentcode," +
                            "claimantprogramcode," +
                            "principalnaicscode," +
                            "informationtechnologycommercialitemcategory," +
                            "gfe_gfp," +
                            "useofepadesignatedproducts," +
                            "recoveredmaterialclauses," +
                            "seatransportation," +
                            "contractbundling," +
                            "consolidatedcontract," +
                            "countryoforigin," +
                            "placeofmanufacture," +
                            "manufacturingorganizationtype," +
                            "agencyid," +
                            "piid," +
                            "modnumber," +
                            "transactionnumber," +
                            "fiscal_year," +
                            "idvagencyid," +
                            "idvpiid," +
                            "idvmodificationnumber," +
                            "solicitationid," +
                            "extentcompeted," +
                            "reasonnotcompeted," +
                            "numberofoffersreceived," +
                            "commercialitemacquisitionprocedures," +
                            "commercialitemtestprogram," +
                            "smallbusinesscompetitivenessdemonstrationprogram," +
                            "a76action," +
                            "competitiveprocedures," +
                            "solicitationprocedures," +
                            "typeofsetaside," +
                            "localareasetaside," +
                            "evaluatedpreference," +
                            "fedbizopps," +
                            "research," +
                            "statutoryexceptiontofairopportunity," +
                            "organizationaltype," +
                            "numberofemployees," +
                            "annualrevenue," +
                            "firm8aflag," +
                            "hubzoneflag," +
                            "sdbflag," +
                            "issbacertifiedsmalldisadvantagedbusiness," +
                            "shelteredworkshopflag," +
                            "hbcuflag," +
                            "educationalinstitutionflag," +
                            "womenownedflag," +
                            "veteranownedflag," +
                            "srdvobflag," +
                            "localgovernmentflag," +
                            "minorityinstitutionflag," +
                            "aiobflag," +
                            "stategovernmentflag," +
                            "federalgovernmentflag," +
                            "minorityownedbusinessflag," +
                            "apaobflag," +
                            "tribalgovernmentflag," +
                            "baobflag," +
                            "naobflag," +
                            "saaobflag," +
                            "nonprofitorganizationflag," +
                            "isothernotforprofitorganization," +
                            "isforprofitorganization," +
                            "isfoundation," +
                            "haobflag," +
                            "ishispanicservicinginstitution," +
                            "emergingsmallbusinessflag," +
                            "hospitalflag," +
                            "contractingofficerbusinesssizedetermination," +
                            "is1862landgrantcollege," +
                            "is1890landgrantcollege," +
                            "is1994landgrantcollege," +
                            "isveterinarycollege," +
                            "isveterinaryhospital," +
                            "isprivateuniversityorcollege," +
                            "isschoolofforestry," +
                            "isstatecontrolledinstitutionofhigherlearning," +
                            "isserviceprovider," +
                            "receivescontracts," +
                            "receivesgrants," +
                            "receivescontractsandgrants," +
                            "isairportauthority," +
                            "iscouncilofgovernments," +
                            "ishousingauthoritiespublicortribal," +
                            "isinterstateentity," +
                            "isplanningcommission," +
                            "isportauthority," +
                            "istransitauthority," +
                            "issubchapterscorporation," +
                            "islimitedliabilitycorporation," +
                            "isforeignownedandlocated," +
                            "isarchitectureandengineering," +
                            "isdotcertifieddisadvantagedbusinessenterprise," +
                            "iscitylocalgovernment," +
                            "iscommunitydevelopedcorporationownedfirm," +
                            "iscommunitydevelopmentcorporation," +
                            "isconstructionfirm," +
                            "ismanufacturerofgoods," +
                            "iscorporateentitynottaxexempt," +
                            "iscountylocalgovernment," +
                            "isdomesticshelter," +
                            "isfederalgovernmentagency," +
                            "isfederallyfundedresearchanddevelopmentcorp," +
                            "isforeigngovernment," +
                            "isindiantribe," +
                            "isintermunicipallocalgovernment," +
                            "isinternationalorganization," +
                            "islaborsurplusareafirm," +
                            "islocalgovernmentowned," +
                            "ismunicipalitylocalgovernment," +
                            "isnativehawaiianownedorganizationorfirm," +
                            "isotherbusinessororganization," +
                            "isotherminorityowned," +
                            "ispartnershiporlimitedliabilitypartnership," +
                            "isschooldistrictlocalgovernment," +
                            "issmallagriculturalcooperative," +
                            "issoleproprietorship," +
                            "istownshiplocalgovernment," +
                            "istriballyownedfirm," +
                            "istribalcollege," +
                            "isalaskannativeownedcorporationorfirm," +
                            "iscorporateentitytaxexempt," +
                            "iswomenownedsmallbusiness," +
                            "isecondisadvwomenownedsmallbusiness," +
                            "isjointventurewomenownedsmallbusiness," +
                            "isjointventureecondisadvwomenownedsmallbusiness," +
                            "walshhealyact," +
                            "servicecontractact," +
                            "davisbaconact," +
                            "clingercohenact," +
                            "otherstatutoryauthority," +
                            "prime_awardee_executive1," +
                            "prime_awardee_executive1_compensation," +
                            "prime_awardee_executive2," +
                            "prime_awardee_executive2_compensation," +
                            "prime_awardee_executive3," +
                            "prime_awardee_executive3_compensation," +
                            "prime_awardee_executive4," +
                            "prime_awardee_executive4_compensation," +
                            "prime_awardee_executive5," +
                            "prime_awardee_executive5_compensation," +
                            "interagencycontractingauthority," +
                            "last_modified_date," +
                "contract_vehicle," +
                "work," +
                "completion_date," +
                "completion_year," +
                            "insert_date," +
                            "insert_user");

            csvrecords.AppendLine(heading.ToString());

            StringBuilder sb = new StringBuilder();

            foreach (var rec in records)
            {


                sb.Append("\"" + rec.unique_transaction_id.ToString() + "\"" + "," +
                         "\"" + rec.transaction_status.ToString() + "\"" + "," +
                         "\"" + rec.dollarsobligated.ToString() + "\"" + "," +
                         "\"" + rec.baseandexercisedoptionsvalue.ToString() + "\"" + "," +
                         "\"" + rec.baseandalloptionsvalue.ToString() + "\"" + "," +
                         "\"" + rec.maj_agency_cat.ToString() + "\"" + "," +
                         "\"" + rec.mod_agency.ToString() + "\"" + "," +
                         "\"" + rec.maj_fund_agency_cat.ToString() + "\"" + "," +
                         "\"" + rec.contractingofficeagencyid.ToString() + "\"" + "," +
                         "\"" + rec.contractingofficeid.ToString() + "\"" + "," +
                         "\"" + rec.fundingrequestingagencyid.ToString() + "\"" + "," +
                         "\"" + rec.fundingrequestingofficeid.ToString() + "\"" + "," +
                         "\"" + rec.fundedbyforeignentity.ToString() + "\"" + "," +
                         "\"" + rec.signeddate.ToString() + "\"" + "," +
                         "\"" + rec.effectivedate.ToString() + "\"" + "," +
                         "\"" + rec.currentcompletiondate.ToString() + "\"" + "," +
                         "\"" + rec.ultimatecompletiondate.ToString() + "\"" + "," +
                         "\"" + rec.lastdatetoorder.ToString() + "\"" + "," +
                         "\"" + rec.contractactiontype.ToString() + "\"" + "," +
                         "\"" + rec.reasonformodification.ToString() + "\"" + "," +
                         "\"" + rec.typeofcontractpricing.ToString() + "\"" + "," +
                         "\"" + rec.priceevaluationpercentdifference.ToString() + "\"" + "," +
                         "\"" + rec.subcontractplan.ToString() + "\"" + "," +
                         "\"" + rec.lettercontract.ToString() + "\"" + "," +
                         "\"" + rec.multiyearcontract.ToString() + "\"" + "," +
                         "\"" + rec.performancebasedservicecontract.ToString() + "\"" + "," +
                         "\"" + rec.majorprogramcode.ToString() + "\"" + "," +
                         "\"" + rec.contingencyhumanitarianpeacekeepingoperation.ToString() + "\"" + "," +
                         "\"" + rec.contractfinancing.ToString() + "\"" + "," +
                         "\"" + rec.costorpricingdata.ToString() + "\"" + "," +
                         "\"" + rec.costaccountingstandardsclause.ToString() + "\"" + "," +
                         "\"" + rec.descriptionofcontractrequirement.ToString() + "\"" + "," +
                         "\"" + rec.purchasecardaspaymentmethod.ToString() + "\"" + "," +
                         "\"" + rec.numberofactions.ToString() + "\"" + "," +
                         "\"" + rec.nationalinterestactioncode.ToString() + "\"" + "," +
                         "\"" + rec.progsourceagency.ToString() + "\"" + "," +
                         "\"" + rec.progsourceaccount.ToString() + "\"" + "," +
                         "\"" + rec.progsourcesubacct.ToString() + "\"" + "," +
                         "\"" + rec.account_title.ToString() + "\"" + "," +
                         "\"" + rec.rec_flag.ToString() + "\"" + "," +
                         "\"" + rec.typeofidc.ToString() + "\"" + "," +
                         "\"" + rec.multipleorsingleawardidc.ToString() + "\"" + "," +
                         "\"" + rec.programacronym.ToString() + "\"" + "," +
                         "\"" + rec.vendorname.ToString() + "\"" + "," +
                         "\"" + rec.vendoralternatename.ToString() + "\"" + "," +
                         "\"" + rec.vendorlegalorganizationname.ToString() + "\"" + "," +
                         "\"" + rec.vendordoingasbusinessname.ToString() + "\"" + "," +
                         "\"" + rec.divisionname.ToString() + "\"" + "," +
                         "\"" + rec.divisionnumberorofficecode.ToString() + "\"" + "," +
                         "\"" + rec.vendorenabled.ToString() + "\"" + "," +
                         "\"" + rec.vendorlocationdisableflag.ToString() + "\"" + "," +
                         "\"" + rec.ccrexception.ToString() + "\"" + "," +
                         "\"" + rec.streetaddress.ToString() + "\"" + "," +
                         "\"" + rec.streetaddress2.ToString() + "\"" + "," +
                         "\"" + rec.streetaddress3.ToString() + "\"" + "," +
                         "\"" + rec.city.ToString() + "\"" + "," +
                         "\"" + rec.state.ToString() + "\"" + "," +
                         "\"" + rec.zipcode.ToString() + "\"" + "," +
                         "\"" + rec.vendorcountrycode.ToString() + "\"" + "," +
                         "\"" + rec.vendor_state_code.ToString() + "\"" + "," +
                         "\"" + rec.vendor_cd.ToString() + "\"" + "," +
                         "\"" + rec.congressionaldistrict.ToString() + "\"" + "," +
                         "\"" + rec.vendorsitecode.ToString() + "\"" + "," +
                         "\"" + rec.vendoralternatesitecode.ToString() + "\"" + "," +
                         "\"" + rec.dunsnumber.ToString() + "\"" + "," +
                         "\"" + rec.parentdunsnumber.ToString() + "\"" + "," +
                         "\"" + rec.phoneno.ToString() + "\"" + "," +
                         "\"" + rec.faxno.ToString() + "\"" + "," +
                         "\"" + rec.registrationdate.ToString() + "\"" + "," +
                         "\"" + rec.renewaldate.ToString() + "\"" + "," +
                         "\"" + rec.mod_parent.ToString() + "\"" + "," +
                         "\"" + rec.locationcode.ToString() + "\"" + "," +
                         "\"" + rec.statecode.ToString() + "\"" + "," +
                         "\"" + rec.placeofperformancecity.ToString() + "\"" + "," +
                         "\"" + rec.pop_state_code.ToString() + "\"" + "," +
                         "\"" + rec.placeofperformancecountrycode.ToString() + "\"" + "," +
                         "\"" + rec.placeofperformancezipcode.ToString() + "\"" + "," +
                         "\"" + rec.pop_cd.ToString() + "\"" + "," +
                         "\"" + rec.placeofperformancecongressionaldistrict.ToString() + "\"" + "," +
                         "\"" + rec.psc_cat.ToString() + "\"" + "," +
                         "\"" + rec.productorservicecode.ToString() + "\"" + "," +
                         "\"" + rec.systemequipmentcode.ToString() + "\"" + "," +
                         "\"" + rec.claimantprogramcode.ToString() + "\"" + "," +
                         "\"" + rec.principalnaicscode.ToString() + "\"" + "," +
                         "\"" + rec.informationtechnologycommercialitemcategory.ToString() + "\"" + "," +
                         "\"" + rec.gfe_gfp.ToString() + "\"" + "," +
                         "\"" + rec.useofepadesignatedproducts.ToString() + "\"" + "," +
                         "\"" + rec.recoveredmaterialclauses.ToString() + "\"" + "," +
                         "\"" + rec.seatransportation.ToString() + "\"" + "," +
                         "\"" + rec.contractbundling.ToString() + "\"" + "," +
                         "\"" + rec.consolidatedcontract.ToString() + "\"" + "," +
                         "\"" + rec.countryoforigin.ToString() + "\"" + "," +
                         "\"" + rec.placeofmanufacture.ToString() + "\"" + "," +
                         "\"" + rec.manufacturingorganizationtype.ToString() + "\"" + "," +
                         "\"" + rec.agencyid.ToString() + "\"" + "," +
                         "\"" + rec.piid.ToString() + "\"" + "," +
                         "\"" + rec.modnumber.ToString() + "\"" + "," +
                         "\"" + rec.transactionnumber.ToString() + "\"" + "," +
                         "\"" + rec.fiscal_year.ToString() + "\"" + "," +
                         "\"" + rec.idvagencyid.ToString() + "\"" + "," +
                         "\"" + rec.idvpiid.ToString() + "\"" + "," +
                         "\"" + rec.idvmodificationnumber.ToString() + "\"" + "," +
                         "\"" + rec.solicitationid.ToString() + "\"" + "," +
                         "\"" + rec.extentcompeted.ToString() + "\"" + "," +
                         "\"" + rec.reasonnotcompeted.ToString() + "\"" + "," +
                         "\"" + rec.numberofoffersreceived.ToString() + "\"" + "," +
                         "\"" + rec.commercialitemacquisitionprocedures.ToString() + "\"" + "," +
                         "\"" + rec.commercialitemtestprogram.ToString() + "\"" + "," +
                         "\"" + rec.smallbusinesscompetitivenessdemonstrationprogram.ToString() + "\"" + "," +
                         "\"" + rec.a76action.ToString() + "\"" + "," +
                         "\"" + rec.competitiveprocedures.ToString() + "\"" + "," +
                         "\"" + rec.solicitationprocedures.ToString() + "\"" + "," +
                         "\"" + rec.typeofsetaside.ToString() + "\"" + "," +
                         "\"" + rec.localareasetaside.ToString() + "\"" + "," +
                         "\"" + rec.evaluatedpreference.ToString() + "\"" + "," +
                         "\"" + rec.fedbizopps.ToString() + "\"" + "," +
                         "\"" + rec.research.ToString() + "\"" + "," +
                         "\"" + rec.statutoryexceptiontofairopportunity.ToString() + "\"" + "," +
                         "\"" + rec.organizationaltype.ToString() + "\"" + "," +
                         "\"" + rec.numberofemployees.ToString() + "\"" + "," +
                         "\"" + rec.annualrevenue.ToString() + "\"" + "," +
                         "\"" + rec.firm8aflag.ToString() + "\"" + "," +
                         "\"" + rec.hubzoneflag.ToString() + "\"" + "," +
                         "\"" + rec.sdbflag.ToString() + "\"" + "," +
                         "\"" + rec.issbacertifiedsmalldisadvantagedbusiness.ToString() + "\"" + "," +
                         "\"" + rec.shelteredworkshopflag.ToString() + "\"" + "," +
                         "\"" + rec.hbcuflag.ToString() + "\"" + "," +
                         "\"" + rec.educationalinstitutionflag.ToString() + "\"" + "," +
                         "\"" + rec.womenownedflag.ToString() + "\"" + "," +
                         "\"" + rec.veteranownedflag.ToString() + "\"" + "," +
                         "\"" + rec.srdvobflag.ToString() + "\"" + "," +
                         "\"" + rec.localgovernmentflag.ToString() + "\"" + "," +
                         "\"" + rec.minorityinstitutionflag.ToString() + "\"" + "," +
                         "\"" + rec.aiobflag.ToString() + "\"" + "," +
                         "\"" + rec.stategovernmentflag.ToString() + "\"" + "," +
                         "\"" + rec.federalgovernmentflag.ToString() + "\"" + "," +
                         "\"" + rec.minorityownedbusinessflag.ToString() + "\"" + "," +
                         "\"" + rec.apaobflag.ToString() + "\"" + "," +
                         "\"" + rec.tribalgovernmentflag.ToString() + "\"" + "," +
                         "\"" + rec.baobflag.ToString() + "\"" + "," +
                         "\"" + rec.naobflag.ToString() + "\"" + "," +
                         "\"" + rec.saaobflag.ToString() + "\"" + "," +
                         "\"" + rec.nonprofitorganizationflag.ToString() + "\"" + "," +
                         "\"" + rec.isothernotforprofitorganization.ToString() + "\"" + "," +
                         "\"" + rec.isforprofitorganization.ToString() + "\"" + "," +
                         "\"" + rec.isfoundation.ToString() + "\"" + "," +
                         "\"" + rec.haobflag.ToString() + "\"" + "," +
                         "\"" + rec.ishispanicservicinginstitution.ToString() + "\"" + "," +
                         "\"" + rec.emergingsmallbusinessflag.ToString() + "\"" + "," +
                         "\"" + rec.hospitalflag.ToString() + "\"" + "," +
                         "\"" + rec.contractingofficerbusinesssizedetermination.ToString() + "\"" + "," +
                         "\"" + rec.is1862landgrantcollege.ToString() + "\"" + "," +
                         "\"" + rec.is1890landgrantcollege.ToString() + "\"" + "," +
                         "\"" + rec.is1994landgrantcollege.ToString() + "\"" + "," +
                         "\"" + rec.isveterinarycollege.ToString() + "\"" + "," +
                         "\"" + rec.isveterinaryhospital.ToString() + "\"" + "," +
                         "\"" + rec.isprivateuniversityorcollege.ToString() + "\"" + "," +
                         "\"" + rec.isschoolofforestry.ToString() + "\"" + "," +
                         "\"" + rec.isstatecontrolledinstitutionofhigherlearning.ToString() + "\"" + "," +
                         "\"" + rec.isserviceprovider.ToString() + "\"" + "," +
                         "\"" + rec.receivescontracts.ToString() + "\"" + "," +
                         "\"" + rec.receivesgrants.ToString() + "\"" + "," +
                         "\"" + rec.receivescontractsandgrants.ToString() + "\"" + "," +
                         "\"" + rec.isairportauthority.ToString() + "\"" + "," +
                         "\"" + rec.iscouncilofgovernments.ToString() + "\"" + "," +
                         "\"" + rec.ishousingauthoritiespublicortribal.ToString() + "\"" + "," +
                         "\"" + rec.isinterstateentity.ToString() + "\"" + "," +
                         "\"" + rec.isplanningcommission.ToString() + "\"" + "," +
                         "\"" + rec.isportauthority.ToString() + "\"" + "," +
                         "\"" + rec.istransitauthority.ToString() + "\"" + "," +
                         "\"" + rec.issubchapterscorporation.ToString() + "\"" + "," +
                         "\"" + rec.islimitedliabilitycorporation.ToString() + "\"" + "," +
                         "\"" + rec.isforeignownedandlocated.ToString() + "\"" + "," +
                         "\"" + rec.isarchitectureandengineering.ToString() + "\"" + "," +
                         "\"" + rec.isdotcertifieddisadvantagedbusinessenterprise.ToString() + "\"" + "," +
                         "\"" + rec.iscitylocalgovernment.ToString() + "\"" + "," +
                         "\"" + rec.iscommunitydevelopedcorporationownedfirm.ToString() + "\"" + "," +
                         "\"" + rec.iscommunitydevelopmentcorporation.ToString() + "\"" + "," +
                         "\"" + rec.isconstructionfirm.ToString() + "\"" + "," +
                         "\"" + rec.ismanufacturerofgoods.ToString() + "\"" + "," +
                         "\"" + rec.iscorporateentitynottaxexempt.ToString() + "\"" + "," +
                         "\"" + rec.iscountylocalgovernment.ToString() + "\"" + "," +
                         "\"" + rec.isdomesticshelter.ToString() + "\"" + "," +
                         "\"" + rec.isfederalgovernmentagency.ToString() + "\"" + "," +
                         "\"" + rec.isfederallyfundedresearchanddevelopmentcorp.ToString() + "\"" + "," +
                         "\"" + rec.isforeigngovernment.ToString() + "\"" + "," +
                         "\"" + rec.isindiantribe.ToString() + "\"" + "," +
                         "\"" + rec.isintermunicipallocalgovernment.ToString() + "\"" + "," +
                         "\"" + rec.isinternationalorganization.ToString() + "\"" + "," +
                         "\"" + rec.islaborsurplusareafirm.ToString() + "\"" + "," +
                         "\"" + rec.islocalgovernmentowned.ToString() + "\"" + "," +
                         "\"" + rec.ismunicipalitylocalgovernment.ToString() + "\"" + "," +
                         "\"" + rec.isnativehawaiianownedorganizationorfirm.ToString() + "\"" + "," +
                         "\"" + rec.isotherbusinessororganization.ToString() + "\"" + "," +
                         "\"" + rec.isotherminorityowned.ToString() + "\"" + "," +
                         "\"" + rec.ispartnershiporlimitedliabilitypartnership.ToString() + "\"" + "," +
                         "\"" + rec.isschooldistrictlocalgovernment.ToString() + "\"" + "," +
                         "\"" + rec.issmallagriculturalcooperative.ToString() + "\"" + "," +
                         "\"" + rec.issoleproprietorship.ToString() + "\"" + "," +
                         "\"" + rec.istownshiplocalgovernment.ToString() + "\"" + "," +
                         "\"" + rec.istriballyownedfirm.ToString() + "\"" + "," +
                         "\"" + rec.istribalcollege.ToString() + "\"" + "," +
                         "\"" + rec.isalaskannativeownedcorporationorfirm.ToString() + "\"" + "," +
                         "\"" + rec.iscorporateentitytaxexempt.ToString() + "\"" + "," +
                         "\"" + rec.iswomenownedsmallbusiness.ToString() + "\"" + "," +
                         "\"" + rec.isecondisadvwomenownedsmallbusiness.ToString() + "\"" + "," +
                         "\"" + rec.isjointventurewomenownedsmallbusiness.ToString() + "\"" + "," +
                         "\"" + rec.isjointventureecondisadvwomenownedsmallbusiness.ToString() + "\"" + "," +
                         "\"" + rec.walshhealyact.ToString() + "\"" + "," +
                         "\"" + rec.servicecontractact.ToString() + "\"" + "," +
                         "\"" + rec.davisbaconact.ToString() + "\"" + "," +
                         "\"" + rec.clingercohenact.ToString() + "\"" + "," +
                         "\"" + rec.otherstatutoryauthority.ToString() + "\"" + "," +
                         "\"" + rec.prime_awardee_executive1.ToString() + "\"" + "," +
                         "\"" + rec.prime_awardee_executive1_compensation.ToString() + "\"" + "," +
                         "\"" + rec.prime_awardee_executive2.ToString() + "\"" + "," +
                         "\"" + rec.prime_awardee_executive2_compensation.ToString() + "\"" + "," +
                         "\"" + rec.prime_awardee_executive3.ToString() + "\"" + "," +
                         "\"" + rec.prime_awardee_executive3_compensation.ToString() + "\"" + "," +
                         "\"" + rec.prime_awardee_executive4.ToString() + "\"" + "," +
                         "\"" + rec.prime_awardee_executive4_compensation.ToString() + "\"" + "," +
                         "\"" + rec.prime_awardee_executive5.ToString() + "\"" + "," +
                         "\"" + rec.prime_awardee_executive5_compensation.ToString() + "\"" + "," +
                         "\"" + rec.interagencycontractingauthority.ToString() + "\"" + "," +
                         "\"" + rec.last_modified_date.ToString() + "\"" + "," );
                             if (rec.contract_vehicle == null)
                          sb.Append("\"" + "\""  +  "," );
                        else
                        {
                           sb.Append( "\"" +  rec.contract_vehicle.ToString() + "\""  +  ",");
                        }
                        if (rec.work == null)

                           sb.Append("\"" + "\""  +  "," );
                        else
                        {
                            sb.Append( "\"" +  rec.work.ToString() + "\""  +  ",");
                        }
                        if (rec.completion_date == null)
                           sb.Append("\"" + "\""  +  "," );
                        else
                        {
                            sb.Append( "\"" +  rec.completion_date.ToString() + "\""  +  ",");
                        }
                        if (rec.completion_year == null)

                            sb.Append("\"" + "\""  +  "," );
                        else
                        {
                            sb.Append( "\"" +  rec.completion_year.ToString() + "\""  +  "," );
                        }
                    // "\"" +  rec.contract_vehicle.ToString() + "\""  +  "," +
                    // "\"" +  rec.work.ToString() + "\""  +  "," +
                    // "\"" +  rec.completion_date.ToString() + "\""  +  "," +
                    // "\"" +  rec.completion_year.ToString() + "\""  +  "," +
                        sb.Append("\"" + rec.insert_date.ToString() + "\"" + "," +
                         "\"" + rec.insert_user.ToString() + "\"");
                   

                csvrecords.AppendLine(sb.ToString());
                sb.Clear();
            }


            return csvrecords.ToString();
        }
        public static String USAspendRecordtoCSV(ObservableCollection<Current_usaspend> records)
        {

            StringBuilder csvrecords = new StringBuilder();

            StringBuilder heading = new StringBuilder();
            heading.Append("unique_transaction_id," +
                            "transaction_status," +
                            "dollarsobligated," +
                            "baseandexercisedoptionsvalue," +
                            "baseandalloptionsvalue," +
                            "maj_agency_cat," +
                            "mod_agency," +
                            "maj_fund_agency_cat," +
                            "contractingofficeagencyid," +
                            "contractingofficeid," +
                            "fundingrequestingagencyid," +
                            "fundingrequestingofficeid," +
                            "fundedbyforeignentity," +
                            "signeddate," +
                            "effectivedate," +
                            "currentcompletiondate," +
                            "ultimatecompletiondate," +
                            "lastdatetoorder," +
                            "contractactiontype," +
                            "reasonformodification," +
                            "typeofcontractpricing," +
                            "priceevaluationpercentdifference," +
                            "subcontractplan," +
                            "lettercontract," +
                            "multiyearcontract," +
                            "performancebasedservicecontract," +
                            "majorprogramcode," +
                            "contingencyhumanitarianpeacekeepingoperation," +
                            "contractfinancing," +
                            "costorpricingdata," +
                            "costaccountingstandardsclause," +
                            "descriptionofcontractrequirement," +
                            "purchasecardaspaymentmethod," +
                            "numberofactions," +
                            "nationalinterestactioncode," +
                            "progsourceagency," +
                            "progsourceaccount," +
                            "progsourcesubacct," +
                            "account_title," +
                            "rec_flag," +
                            "typeofidc," +
                            "multipleorsingleawardidc," +
                            "programacronym," +
                            "vendorname," +
                            "vendoralternatename," +
                            "vendorlegalorganizationname," +
                            "vendordoingasbusinessname," +
                            "divisionname," +
                            "divisionnumberorofficecode," +
                            "vendorenabled," +
                            "vendorlocationdisableflag," +
                            "ccrexception," +
                            "streetaddress," +
                            "streetaddress2," +
                            "streetaddress3," +
                            "city," +
                            "state," +
                            "zipcode," +
                            "vendorcountrycode," +
                            "vendor_state_code," +
                            "vendor_cd," +
                            "congressionaldistrict," +
                            "vendorsitecode," +
                            "vendoralternatesitecode," +
                            "dunsnumber," +
                            "parentdunsnumber," +
                            "phoneno," +
                            "faxno," +
                            "registrationdate," +
                            "renewaldate," +
                            "mod_parent," +
                            "locationcode," +
                            "statecode," +
                            "placeofperformancecity," +
                            "pop_state_code," +
                            "placeofperformancecountrycode," +
                            "placeofperformancezipcode," +
                            "pop_cd," +
                            "placeofperformancecongressionaldistrict," +
                            "psc_cat," +
                            "productorservicecode," +
                            "systemequipmentcode," +
                            "claimantprogramcode," +
                            "principalnaicscode," +
                            "informationtechnologycommercialitemcategory," +
                            "gfe_gfp," +
                            "useofepadesignatedproducts," +
                            "recoveredmaterialclauses," +
                            "seatransportation," +
                            "contractbundling," +
                            "consolidatedcontract," +
                            "countryoforigin," +
                            "placeofmanufacture," +
                            "manufacturingorganizationtype," +
                            "agencyid," +
                            "piid," +
                            "modnumber," +
                            "transactionnumber," +
                            "fiscal_year," +
                            "idvagencyid," +
                            "idvpiid," +
                            "idvmodificationnumber," +
                            "solicitationid," +
                            "extentcompeted," +
                            "reasonnotcompeted," +
                            "numberofoffersreceived," +
                            "commercialitemacquisitionprocedures," +
                            "commercialitemtestprogram," +
                            "smallbusinesscompetitivenessdemonstrationprogram," +
                            "a76action," +
                            "competitiveprocedures," +
                            "solicitationprocedures," +
                            "typeofsetaside," +
                            "localareasetaside," +
                            "evaluatedpreference," +
                            "fedbizopps," +
                            "research," +
                            "statutoryexceptiontofairopportunity," +
                            "organizationaltype," +
                            "numberofemployees," +
                            "annualrevenue," +
                            "firm8aflag," +
                            "hubzoneflag," +
                            "sdbflag," +
                            "issbacertifiedsmalldisadvantagedbusiness," +
                            "shelteredworkshopflag," +
                            "hbcuflag," +
                            "educationalinstitutionflag," +
                            "womenownedflag," +
                            "veteranownedflag," +
                            "srdvobflag," +
                            "localgovernmentflag," +
                            "minorityinstitutionflag," +
                            "aiobflag," +
                            "stategovernmentflag," +
                            "federalgovernmentflag," +
                            "minorityownedbusinessflag," +
                            "apaobflag," +
                            "tribalgovernmentflag," +
                            "baobflag," +
                            "naobflag," +
                            "saaobflag," +
                            "nonprofitorganizationflag," +
                            "isothernotforprofitorganization," +
                            "isforprofitorganization," +
                            "isfoundation," +
                            "haobflag," +
                            "ishispanicservicinginstitution," +
                            "emergingsmallbusinessflag," +
                            "hospitalflag," +
                            "contractingofficerbusinesssizedetermination," +
                            "is1862landgrantcollege," +
                            "is1890landgrantcollege," +
                            "is1994landgrantcollege," +
                            "isveterinarycollege," +
                            "isveterinaryhospital," +
                            "isprivateuniversityorcollege," +
                            "isschoolofforestry," +
                            "isstatecontrolledinstitutionofhigherlearning," +
                            "isserviceprovider," +
                            "receivescontracts," +
                            "receivesgrants," +
                            "receivescontractsandgrants," +
                            "isairportauthority," +
                            "iscouncilofgovernments," +
                            "ishousingauthoritiespublicortribal," +
                            "isinterstateentity," +
                            "isplanningcommission," +
                            "isportauthority," +
                            "istransitauthority," +
                            "issubchapterscorporation," +
                            "islimitedliabilitycorporation," +
                            "isforeignownedandlocated," +
                            "isarchitectureandengineering," +
                            "isdotcertifieddisadvantagedbusinessenterprise," +
                            "iscitylocalgovernment," +
                            "iscommunitydevelopedcorporationownedfirm," +
                            "iscommunitydevelopmentcorporation," +
                            "isconstructionfirm," +
                            "ismanufacturerofgoods," +
                            "iscorporateentitynottaxexempt," +
                            "iscountylocalgovernment," +
                            "isdomesticshelter," +
                            "isfederalgovernmentagency," +
                            "isfederallyfundedresearchanddevelopmentcorp," +
                            "isforeigngovernment," +
                            "isindiantribe," +
                            "isintermunicipallocalgovernment," +
                            "isinternationalorganization," +
                            "islaborsurplusareafirm," +
                            "islocalgovernmentowned," +
                            "ismunicipalitylocalgovernment," +
                            "isnativehawaiianownedorganizationorfirm," +
                            "isotherbusinessororganization," +
                            "isotherminorityowned," +
                            "ispartnershiporlimitedliabilitypartnership," +
                            "isschooldistrictlocalgovernment," +
                            "issmallagriculturalcooperative," +
                            "issoleproprietorship," +
                            "istownshiplocalgovernment," +
                            "istriballyownedfirm," +
                            "istribalcollege," +
                            "isalaskannativeownedcorporationorfirm," +
                            "iscorporateentitytaxexempt," +
                            "iswomenownedsmallbusiness," +
                            "isecondisadvwomenownedsmallbusiness," +
                            "isjointventurewomenownedsmallbusiness," +
                            "isjointventureecondisadvwomenownedsmallbusiness," +
                            "walshhealyact," +
                            "servicecontractact," +
                            "davisbaconact," +
                            "clingercohenact," +
                            "otherstatutoryauthority," +
                            "prime_awardee_executive1," +
                            "prime_awardee_executive1_compensation," +
                            "prime_awardee_executive2," +
                            "prime_awardee_executive2_compensation," +
                            "prime_awardee_executive3," +
                            "prime_awardee_executive3_compensation," +
                            "prime_awardee_executive4," +
                            "prime_awardee_executive4_compensation," +
                            "prime_awardee_executive5," +
                            "prime_awardee_executive5_compensation," +
                            "interagencycontractingauthority," +
                            "last_modified_date," +
                "contract_vehicle," +
                "work," +
                "completion_date," +
                "completion_year," +
                            "insert_date," +
                            "insert_user");

            csvrecords.AppendLine(heading.ToString());

            StringBuilder sb = new StringBuilder();

            foreach (var rec in records)
            {


                sb.Append("\"" + rec.unique_transaction_id.ToString() + "\"" + "," +
                         "\"" + rec.transaction_status.ToString() + "\"" + "," +
                         "\"" + rec.dollarsobligated.ToString() + "\"" + "," +
                         "\"" + rec.baseandexercisedoptionsvalue.ToString() + "\"" + "," +
                         "\"" + rec.baseandalloptionsvalue.ToString() + "\"" + "," +
                         "\"" + rec.maj_agency_cat.ToString() + "\"" + "," +
                         "\"" + rec.mod_agency.ToString() + "\"" + "," +
                         "\"" + rec.maj_fund_agency_cat.ToString() + "\"" + "," +
                         "\"" + rec.contractingofficeagencyid.ToString() + "\"" + "," +
                         "\"" + rec.contractingofficeid.ToString() + "\"" + "," +
                         "\"" + rec.fundingrequestingagencyid.ToString() + "\"" + "," +
                         "\"" + rec.fundingrequestingofficeid.ToString() + "\"" + "," +
                         "\"" + rec.fundedbyforeignentity.ToString() + "\"" + "," +
                         "\"" + rec.signeddate.ToString() + "\"" + "," +
                         "\"" + rec.effectivedate.ToString() + "\"" + "," +
                         "\"" + rec.currentcompletiondate.ToString() + "\"" + "," +
                         "\"" + rec.ultimatecompletiondate.ToString() + "\"" + "," +
                         "\"" + rec.lastdatetoorder.ToString() + "\"" + "," +
                         "\"" + rec.contractactiontype.ToString() + "\"" + "," +
                         "\"" + rec.reasonformodification.ToString() + "\"" + "," +
                         "\"" + rec.typeofcontractpricing.ToString() + "\"" + "," +
                         "\"" + rec.priceevaluationpercentdifference.ToString() + "\"" + "," +
                         "\"" + rec.subcontractplan.ToString() + "\"" + "," +
                         "\"" + rec.lettercontract.ToString() + "\"" + "," +
                         "\"" + rec.multiyearcontract.ToString() + "\"" + "," +
                         "\"" + rec.performancebasedservicecontract.ToString() + "\"" + "," +
                         "\"" + rec.majorprogramcode.ToString() + "\"" + "," +
                         "\"" + rec.contingencyhumanitarianpeacekeepingoperation.ToString() + "\"" + "," +
                         "\"" + rec.contractfinancing.ToString() + "\"" + "," +
                         "\"" + rec.costorpricingdata.ToString() + "\"" + "," +
                         "\"" + rec.costaccountingstandardsclause.ToString() + "\"" + "," +
                         "\"" + rec.descriptionofcontractrequirement.ToString() + "\"" + "," +
                         "\"" + rec.purchasecardaspaymentmethod.ToString() + "\"" + "," +
                         "\"" + rec.numberofactions.ToString() + "\"" + "," +
                         "\"" + rec.nationalinterestactioncode.ToString() + "\"" + "," +
                         "\"" + rec.progsourceagency.ToString() + "\"" + "," +
                         "\"" + rec.progsourceaccount.ToString() + "\"" + "," +
                         "\"" + rec.progsourcesubacct.ToString() + "\"" + "," +
                         "\"" + rec.account_title.ToString() + "\"" + "," +
                         "\"" + rec.rec_flag.ToString() + "\"" + "," +
                         "\"" + rec.typeofidc.ToString() + "\"" + "," +
                         "\"" + rec.multipleorsingleawardidc.ToString() + "\"" + "," +
                         "\"" + rec.programacronym.ToString() + "\"" + "," +
                         "\"" + rec.vendorname.ToString() + "\"" + "," +
                         "\"" + rec.vendoralternatename.ToString() + "\"" + "," +
                         "\"" + rec.vendorlegalorganizationname.ToString() + "\"" + "," +
                         "\"" + rec.vendordoingasbusinessname.ToString() + "\"" + "," +
                         "\"" + rec.divisionname.ToString() + "\"" + "," +
                         "\"" + rec.divisionnumberorofficecode.ToString() + "\"" + "," +
                         "\"" + rec.vendorenabled.ToString() + "\"" + "," +
                         "\"" + rec.vendorlocationdisableflag.ToString() + "\"" + "," +
                         "\"" + rec.ccrexception.ToString() + "\"" + "," +
                         "\"" + rec.streetaddress.ToString() + "\"" + "," +
                         "\"" + rec.streetaddress2.ToString() + "\"" + "," +
                         "\"" + rec.streetaddress3.ToString() + "\"" + "," +
                         "\"" + rec.city.ToString() + "\"" + "," +
                         "\"" + rec.state.ToString() + "\"" + "," +
                         "\"" + rec.zipcode.ToString() + "\"" + "," +
                         "\"" + rec.vendorcountrycode.ToString() + "\"" + "," +
                         "\"" + rec.vendor_state_code.ToString() + "\"" + "," +
                         "\"" + rec.vendor_cd.ToString() + "\"" + "," +
                         "\"" + rec.congressionaldistrict.ToString() + "\"" + "," +
                         "\"" + rec.vendorsitecode.ToString() + "\"" + "," +
                         "\"" + rec.vendoralternatesitecode.ToString() + "\"" + "," +
                         "\"" + rec.dunsnumber.ToString() + "\"" + "," +
                         "\"" + rec.parentdunsnumber.ToString() + "\"" + "," +
                         "\"" + rec.phoneno.ToString() + "\"" + "," +
                         "\"" + rec.faxno.ToString() + "\"" + "," +
                         "\"" + rec.registrationdate.ToString() + "\"" + "," +
                         "\"" + rec.renewaldate.ToString() + "\"" + "," +
                         "\"" + rec.mod_parent.ToString() + "\"" + "," +
                         "\"" + rec.locationcode.ToString() + "\"" + "," +
                         "\"" + rec.statecode.ToString() + "\"" + "," +
                         "\"" + rec.placeofperformancecity.ToString() + "\"" + "," +
                         "\"" + rec.pop_state_code.ToString() + "\"" + "," +
                         "\"" + rec.placeofperformancecountrycode.ToString() + "\"" + "," +
                         "\"" + rec.placeofperformancezipcode.ToString() + "\"" + "," +
                         "\"" + rec.pop_cd.ToString() + "\"" + "," +
                         "\"" + rec.placeofperformancecongressionaldistrict.ToString() + "\"" + "," +
                         "\"" + rec.psc_cat.ToString() + "\"" + "," +
                         "\"" + rec.productorservicecode.ToString() + "\"" + "," +
                         "\"" + rec.systemequipmentcode.ToString() + "\"" + "," +
                         "\"" + rec.claimantprogramcode.ToString() + "\"" + "," +
                         "\"" + rec.principalnaicscode.ToString() + "\"" + "," +
                         "\"" + rec.informationtechnologycommercialitemcategory.ToString() + "\"" + "," +
                         "\"" + rec.gfe_gfp.ToString() + "\"" + "," +
                         "\"" + rec.useofepadesignatedproducts.ToString() + "\"" + "," +
                         "\"" + rec.recoveredmaterialclauses.ToString() + "\"" + "," +
                         "\"" + rec.seatransportation.ToString() + "\"" + "," +
                         "\"" + rec.contractbundling.ToString() + "\"" + "," +
                         "\"" + rec.consolidatedcontract.ToString() + "\"" + "," +
                         "\"" + rec.countryoforigin.ToString() + "\"" + "," +
                         "\"" + rec.placeofmanufacture.ToString() + "\"" + "," +
                         "\"" + rec.manufacturingorganizationtype.ToString() + "\"" + "," +
                         "\"" + rec.agencyid.ToString() + "\"" + "," +
                         "\"" + rec.piid.ToString() + "\"" + "," +
                         "\"" + rec.modnumber.ToString() + "\"" + "," +
                         "\"" + rec.transactionnumber.ToString() + "\"" + "," +
                         "\"" + rec.fiscal_year.ToString() + "\"" + "," +
                         "\"" + rec.idvagencyid.ToString() + "\"" + "," +
                         "\"" + rec.idvpiid.ToString() + "\"" + "," +
                         "\"" + rec.idvmodificationnumber.ToString() + "\"" + "," +
                         "\"" + rec.solicitationid.ToString() + "\"" + "," +
                         "\"" + rec.extentcompeted.ToString() + "\"" + "," +
                         "\"" + rec.reasonnotcompeted.ToString() + "\"" + "," +
                         "\"" + rec.numberofoffersreceived.ToString() + "\"" + "," +
                         "\"" + rec.commercialitemacquisitionprocedures.ToString() + "\"" + "," +
                         "\"" + rec.commercialitemtestprogram.ToString() + "\"" + "," +
                         "\"" + rec.smallbusinesscompetitivenessdemonstrationprogram.ToString() + "\"" + "," +
                         "\"" + rec.a76action.ToString() + "\"" + "," +
                         "\"" + rec.competitiveprocedures.ToString() + "\"" + "," +
                         "\"" + rec.solicitationprocedures.ToString() + "\"" + "," +
                         "\"" + rec.typeofsetaside.ToString() + "\"" + "," +
                         "\"" + rec.localareasetaside.ToString() + "\"" + "," +
                         "\"" + rec.evaluatedpreference.ToString() + "\"" + "," +
                         "\"" + rec.fedbizopps.ToString() + "\"" + "," +
                         "\"" + rec.research.ToString() + "\"" + "," +
                         "\"" + rec.statutoryexceptiontofairopportunity.ToString() + "\"" + "," +
                         "\"" + rec.organizationaltype.ToString() + "\"" + "," +
                         "\"" + rec.numberofemployees.ToString() + "\"" + "," +
                         "\"" + rec.annualrevenue.ToString() + "\"" + "," +
                         "\"" + rec.firm8aflag.ToString() + "\"" + "," +
                         "\"" + rec.hubzoneflag.ToString() + "\"" + "," +
                         "\"" + rec.sdbflag.ToString() + "\"" + "," +
                         "\"" + rec.issbacertifiedsmalldisadvantagedbusiness.ToString() + "\"" + "," +
                         "\"" + rec.shelteredworkshopflag.ToString() + "\"" + "," +
                         "\"" + rec.hbcuflag.ToString() + "\"" + "," +
                         "\"" + rec.educationalinstitutionflag.ToString() + "\"" + "," +
                         "\"" + rec.womenownedflag.ToString() + "\"" + "," +
                         "\"" + rec.veteranownedflag.ToString() + "\"" + "," +
                         "\"" + rec.srdvobflag.ToString() + "\"" + "," +
                         "\"" + rec.localgovernmentflag.ToString() + "\"" + "," +
                         "\"" + rec.minorityinstitutionflag.ToString() + "\"" + "," +
                         "\"" + rec.aiobflag.ToString() + "\"" + "," +
                         "\"" + rec.stategovernmentflag.ToString() + "\"" + "," +
                         "\"" + rec.federalgovernmentflag.ToString() + "\"" + "," +
                         "\"" + rec.minorityownedbusinessflag.ToString() + "\"" + "," +
                         "\"" + rec.apaobflag.ToString() + "\"" + "," +
                         "\"" + rec.tribalgovernmentflag.ToString() + "\"" + "," +
                         "\"" + rec.baobflag.ToString() + "\"" + "," +
                         "\"" + rec.naobflag.ToString() + "\"" + "," +
                         "\"" + rec.saaobflag.ToString() + "\"" + "," +
                         "\"" + rec.nonprofitorganizationflag.ToString() + "\"" + "," +
                         "\"" + rec.isothernotforprofitorganization.ToString() + "\"" + "," +
                         "\"" + rec.isforprofitorganization.ToString() + "\"" + "," +
                         "\"" + rec.isfoundation.ToString() + "\"" + "," +
                         "\"" + rec.haobflag.ToString() + "\"" + "," +
                         "\"" + rec.ishispanicservicinginstitution.ToString() + "\"" + "," +
                         "\"" + rec.emergingsmallbusinessflag.ToString() + "\"" + "," +
                         "\"" + rec.hospitalflag.ToString() + "\"" + "," +
                         "\"" + rec.contractingofficerbusinesssizedetermination.ToString() + "\"" + "," +
                         "\"" + rec.is1862landgrantcollege.ToString() + "\"" + "," +
                         "\"" + rec.is1890landgrantcollege.ToString() + "\"" + "," +
                         "\"" + rec.is1994landgrantcollege.ToString() + "\"" + "," +
                         "\"" + rec.isveterinarycollege.ToString() + "\"" + "," +
                         "\"" + rec.isveterinaryhospital.ToString() + "\"" + "," +
                         "\"" + rec.isprivateuniversityorcollege.ToString() + "\"" + "," +
                         "\"" + rec.isschoolofforestry.ToString() + "\"" + "," +
                         "\"" + rec.isstatecontrolledinstitutionofhigherlearning.ToString() + "\"" + "," +
                         "\"" + rec.isserviceprovider.ToString() + "\"" + "," +
                         "\"" + rec.receivescontracts.ToString() + "\"" + "," +
                         "\"" + rec.receivesgrants.ToString() + "\"" + "," +
                         "\"" + rec.receivescontractsandgrants.ToString() + "\"" + "," +
                         "\"" + rec.isairportauthority.ToString() + "\"" + "," +
                         "\"" + rec.iscouncilofgovernments.ToString() + "\"" + "," +
                         "\"" + rec.ishousingauthoritiespublicortribal.ToString() + "\"" + "," +
                         "\"" + rec.isinterstateentity.ToString() + "\"" + "," +
                         "\"" + rec.isplanningcommission.ToString() + "\"" + "," +
                         "\"" + rec.isportauthority.ToString() + "\"" + "," +
                         "\"" + rec.istransitauthority.ToString() + "\"" + "," +
                         "\"" + rec.issubchapterscorporation.ToString() + "\"" + "," +
                         "\"" + rec.islimitedliabilitycorporation.ToString() + "\"" + "," +
                         "\"" + rec.isforeignownedandlocated.ToString() + "\"" + "," +
                         "\"" + rec.isarchitectureandengineering.ToString() + "\"" + "," +
                         "\"" + rec.isdotcertifieddisadvantagedbusinessenterprise.ToString() + "\"" + "," +
                         "\"" + rec.iscitylocalgovernment.ToString() + "\"" + "," +
                         "\"" + rec.iscommunitydevelopedcorporationownedfirm.ToString() + "\"" + "," +
                         "\"" + rec.iscommunitydevelopmentcorporation.ToString() + "\"" + "," +
                         "\"" + rec.isconstructionfirm.ToString() + "\"" + "," +
                         "\"" + rec.ismanufacturerofgoods.ToString() + "\"" + "," +
                         "\"" + rec.iscorporateentitynottaxexempt.ToString() + "\"" + "," +
                         "\"" + rec.iscountylocalgovernment.ToString() + "\"" + "," +
                         "\"" + rec.isdomesticshelter.ToString() + "\"" + "," +
                         "\"" + rec.isfederalgovernmentagency.ToString() + "\"" + "," +
                         "\"" + rec.isfederallyfundedresearchanddevelopmentcorp.ToString() + "\"" + "," +
                         "\"" + rec.isforeigngovernment.ToString() + "\"" + "," +
                         "\"" + rec.isindiantribe.ToString() + "\"" + "," +
                         "\"" + rec.isintermunicipallocalgovernment.ToString() + "\"" + "," +
                         "\"" + rec.isinternationalorganization.ToString() + "\"" + "," +
                         "\"" + rec.islaborsurplusareafirm.ToString() + "\"" + "," +
                         "\"" + rec.islocalgovernmentowned.ToString() + "\"" + "," +
                         "\"" + rec.ismunicipalitylocalgovernment.ToString() + "\"" + "," +
                         "\"" + rec.isnativehawaiianownedorganizationorfirm.ToString() + "\"" + "," +
                         "\"" + rec.isotherbusinessororganization.ToString() + "\"" + "," +
                         "\"" + rec.isotherminorityowned.ToString() + "\"" + "," +
                         "\"" + rec.ispartnershiporlimitedliabilitypartnership.ToString() + "\"" + "," +
                         "\"" + rec.isschooldistrictlocalgovernment.ToString() + "\"" + "," +
                         "\"" + rec.issmallagriculturalcooperative.ToString() + "\"" + "," +
                         "\"" + rec.issoleproprietorship.ToString() + "\"" + "," +
                         "\"" + rec.istownshiplocalgovernment.ToString() + "\"" + "," +
                         "\"" + rec.istriballyownedfirm.ToString() + "\"" + "," +
                         "\"" + rec.istribalcollege.ToString() + "\"" + "," +
                         "\"" + rec.isalaskannativeownedcorporationorfirm.ToString() + "\"" + "," +
                         "\"" + rec.iscorporateentitytaxexempt.ToString() + "\"" + "," +
                         "\"" + rec.iswomenownedsmallbusiness.ToString() + "\"" + "," +
                         "\"" + rec.isecondisadvwomenownedsmallbusiness.ToString() + "\"" + "," +
                         "\"" + rec.isjointventurewomenownedsmallbusiness.ToString() + "\"" + "," +
                         "\"" + rec.isjointventureecondisadvwomenownedsmallbusiness.ToString() + "\"" + "," +
                         "\"" + rec.walshhealyact.ToString() + "\"" + "," +
                         "\"" + rec.servicecontractact.ToString() + "\"" + "," +
                         "\"" + rec.davisbaconact.ToString() + "\"" + "," +
                         "\"" + rec.clingercohenact.ToString() + "\"" + "," +
                         "\"" + rec.otherstatutoryauthority.ToString() + "\"" + "," +
                         "\"" + rec.prime_awardee_executive1.ToString() + "\"" + "," +
                         "\"" + rec.prime_awardee_executive1_compensation.ToString() + "\"" + "," +
                         "\"" + rec.prime_awardee_executive2.ToString() + "\"" + "," +
                         "\"" + rec.prime_awardee_executive2_compensation.ToString() + "\"" + "," +
                         "\"" + rec.prime_awardee_executive3.ToString() + "\"" + "," +
                         "\"" + rec.prime_awardee_executive3_compensation.ToString() + "\"" + "," +
                         "\"" + rec.prime_awardee_executive4.ToString() + "\"" + "," +
                         "\"" + rec.prime_awardee_executive4_compensation.ToString() + "\"" + "," +
                         "\"" + rec.prime_awardee_executive5.ToString() + "\"" + "," +
                         "\"" + rec.prime_awardee_executive5_compensation.ToString() + "\"" + "," +
                         "\"" + rec.interagencycontractingauthority.ToString() + "\"" + "," +
                         "\"" + rec.last_modified_date.ToString() + "\"" + "," );
                          if (rec.contract_vehicle == null)
                          sb.Append("\"" + "\""  +  "," );
                        else
                        {
                           sb.Append( "\"" +  rec.contract_vehicle.ToString() + "\""  +  ",");
                        }
                        if (rec.work == null)

                           sb.Append("\"" + "\""  +  "," );
                        else
                        {
                            sb.Append( "\"" +  rec.work.ToString() + "\""  +  ",");
                        }
                        if (rec.completion_date == null)
                           sb.Append("\"" + "\""  +  "," );
                        else
                        {
                            sb.Append( "\"" +  rec.completion_date.ToString() + "\""  +  ",");
                        }
                        if (rec.completion_year == null)

                            sb.Append("\"" + "\""  +  "," );
                        else
                        {
                            sb.Append( "\"" +  rec.completion_year.ToString() + "\""  +  "," );
                        }
                    // "\"" +  rec.contract_vehicle.ToString() + "\""  +  "," +
                    // "\"" +  rec.work.ToString() + "\""  +  "," +
                    // "\"" +  rec.completion_date.ToString() + "\""  +  "," +
                    // "\"" +  rec.completion_year.ToString() + "\""  +  "," +
                        sb.Append("\"" + rec.insert_date.ToString() + "\"" + "," +
                         "\"" + rec.insert_user.ToString() + "\"");

                csvrecords.AppendLine(sb.ToString());
                sb.Clear();
            }


            return csvrecords.ToString();
        }
        public static List<ComboBoxDisplayValue> USAspendRecordDetaildisplay(Current_usaspend rec)
        {
            List<ComboBoxDisplayValue> thelist = new List<ComboBoxDisplayValue>();



            thelist.Add(new ComboBoxDisplayValue("unique_transaction_id", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("transaction_status", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("dollarsobligated", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("baseandexercisedoptionsvalue", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("baseandalloptionsvalue", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("maj_agency_cat", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("mod_agency", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("maj_fund_agency_cat", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("contractingofficeagencyid", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("contractingofficeid", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("fundingrequestingagencyid", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("fundingrequestingofficeid", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("fundedbyforeignentity", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("signeddate", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("effectivedate", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("currentcompletiondate", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("ultimatecompletiondate", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("lastdatetoorder", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("contractactiontype", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("reasonformodification", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("typeofcontractpricing", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("priceevaluationpercentdifference", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("subcontractplan", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("lettercontract", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("multiyearcontract", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("performancebasedservicecontract", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("majorprogramcode", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("contingencyhumanitarianpeacekeepingoperation", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("contractfinancing", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("costorpricingdata", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("costaccountingstandardsclause", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("descriptionofcontractrequirement", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("purchasecardaspaymentmethod", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("numberofactions", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("nationalinterestactioncode", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("progsourceagency", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("progsourceaccount", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("progsourcesubacct", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("account_title", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("rec_flag", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("typeofidc", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("multipleorsingleawardidc", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("programacronym", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("vendorname", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("vendoralternatename", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("vendorlegalorganizationname", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("vendordoingasbusinessname", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("divisionname", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("divisionnumberorofficecode", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("vendorenabled", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("vendorlocationdisableflag", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("ccrexception", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("streetaddress", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("streetaddress2", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("streetaddress3", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("city", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("state", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("zipcode", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("vendorcountrycode", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("vendor_state_code", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("vendor_cd", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("congressionaldistrict", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("vendorsitecode", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("vendoralternatesitecode", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("dunsnumber", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("parentdunsnumber", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("phoneno", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("faxno", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("registrationdate", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("renewaldate", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("mod_parent", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("locationcode", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("statecode", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("placeofperformancecity", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("pop_state_code", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("placeofperformancecountrycode", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("placeofperformancezipcode", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("pop_cd", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("placeofperformancecongressionaldistrict", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("psc_cat", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("productorservicecode", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("systemequipmentcode", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("claimantprogramcode", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("principalnaicscode", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("informationtechnologycommercialitemcategory", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("gfe_gfp", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("useofepadesignatedproducts", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("recoveredmaterialclauses", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("seatransportation", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("contractbundling", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("consolidatedcontract", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("countryoforigin", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("placeofmanufacture", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("manufacturingorganizationtype", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("agencyid", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("piid", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("modnumber", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("transactionnumber", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("fiscal_year", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("idvagencyid", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("idvpiid", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("idvmodificationnumber", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("solicitationid", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("extentcompeted", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("reasonnotcompeted", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("numberofoffersreceived", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("commercialitemacquisitionprocedures", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("commercialitemtestprogram", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("smallbusinesscompetitivenessdemonstrationprogram", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("a76action", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("competitiveprocedures", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("solicitationprocedures", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("typeofsetaside", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("localareasetaside", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("evaluatedpreference", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("fedbizopps", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("research", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("statutoryexceptiontofairopportunity", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("organizationaltype", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("numberofemployees", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("annualrevenue", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("firm8aflag", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("hubzoneflag", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("sdbflag", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("issbacertifiedsmalldisadvantagedbusiness", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("shelteredworkshopflag", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("hbcuflag", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("educationalinstitutionflag", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("womenownedflag", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("veteranownedflag", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("srdvobflag", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("localgovernmentflag", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("minorityinstitutionflag", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("aiobflag", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("stategovernmentflag", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("federalgovernmentflag", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("minorityownedbusinessflag", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("apaobflag", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("tribalgovernmentflag", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("baobflag", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("naobflag", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("saaobflag", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("nonprofitorganizationflag", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isothernotforprofitorganization", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isforprofitorganization", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isfoundation", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("haobflag", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("ishispanicservicinginstitution", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("emergingsmallbusinessflag", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("hospitalflag", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("contractingofficerbusinesssizedetermination", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("is1862landgrantcollege", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("is1890landgrantcollege", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("is1994landgrantcollege", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isveterinarycollege", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isveterinaryhospital", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isprivateuniversityorcollege", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isschoolofforestry", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isstatecontrolledinstitutionofhigherlearning", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isserviceprovider", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("receivescontracts", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("receivesgrants", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("receivescontractsandgrants", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isairportauthority", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("iscouncilofgovernments", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("ishousingauthoritiespublicortribal", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isinterstateentity", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isplanningcommission", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isportauthority", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("istransitauthority", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("issubchapterscorporation", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("islimitedliabilitycorporation", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isforeignownedandlocated", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isarchitectureandengineering", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isdotcertifieddisadvantagedbusinessenterprise", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("iscitylocalgovernment", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("iscommunitydevelopedcorporationownedfirm", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("iscommunitydevelopmentcorporation", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isconstructionfirm", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("ismanufacturerofgoods", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("iscorporateentitynottaxexempt", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("iscountylocalgovernment", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isdomesticshelter", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isfederalgovernmentagency", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isfederallyfundedresearchanddevelopmentcorp", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isforeigngovernment", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isindiantribe", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isintermunicipallocalgovernment", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isinternationalorganization", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("islaborsurplusareafirm", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("islocalgovernmentowned", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("ismunicipalitylocalgovernment", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isnativehawaiianownedorganizationorfirm", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isotherbusinessororganization", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isotherminorityowned", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("ispartnershiporlimitedliabilitypartnership", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isschooldistrictlocalgovernment", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("issmallagriculturalcooperative", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("issoleproprietorship", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("istownshiplocalgovernment", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("istriballyownedfirm", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("istribalcollege", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isalaskannativeownedcorporationorfirm", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("iscorporateentitytaxexempt", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("iswomenownedsmallbusiness", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isecondisadvwomenownedsmallbusiness", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isjointventurewomenownedsmallbusiness", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("isjointventureecondisadvwomenownedsmallbusiness", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("walshhealyact", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("servicecontractact", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("davisbaconact", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("clingercohenact", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("otherstatutoryauthority", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("prime_awardee_executive1", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("prime_awardee_executive1_compensation", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("prime_awardee_executive2", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("prime_awardee_executive2_compensation", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("prime_awardee_executive3", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("prime_awardee_executive3_compensation", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("prime_awardee_executive4", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("prime_awardee_executive4_compensation", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("prime_awardee_executive5", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("prime_awardee_executive5_compensation", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("interagencycontractingauthority", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("last_modified_date", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("contract_vehicle", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("work", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("completion_date", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("completion_year", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("insert_date", String.Empty));
            thelist.Add(new ComboBoxDisplayValue("insert_user", String.Empty));



            int i = 0;


            thelist[i].Value = rec.unique_transaction_id.ToString(); i++;
            thelist[i].Value = rec.transaction_status.ToString(); i++;
            thelist[i].Value = rec.dollarsobligated.ToString(); i++;
            thelist[i].Value = rec.baseandexercisedoptionsvalue.ToString(); i++;
            thelist[i].Value = rec.baseandalloptionsvalue.ToString(); i++;
            thelist[i].Value = rec.maj_agency_cat.ToString(); i++;
            thelist[i].Value = rec.mod_agency.ToString(); i++;
            thelist[i].Value = rec.maj_fund_agency_cat.ToString(); i++;
            thelist[i].Value = rec.contractingofficeagencyid.ToString(); i++;
            thelist[i].Value = rec.contractingofficeid.ToString(); i++;
            thelist[i].Value = rec.fundingrequestingagencyid.ToString(); i++;
            thelist[i].Value = rec.fundingrequestingofficeid.ToString(); i++;
            thelist[i].Value = rec.fundedbyforeignentity.ToString(); i++;
            thelist[i].Value = rec.signeddate.ToString(); i++;
            thelist[i].Value = rec.effectivedate.ToString(); i++;
            thelist[i].Value = rec.currentcompletiondate.ToString(); i++;
            thelist[i].Value = rec.ultimatecompletiondate.ToString(); i++;
            thelist[i].Value = rec.lastdatetoorder.ToString(); i++;
            thelist[i].Value = rec.contractactiontype.ToString(); i++;
            thelist[i].Value = rec.reasonformodification.ToString(); i++;
            thelist[i].Value = rec.typeofcontractpricing.ToString(); i++;
            thelist[i].Value = rec.priceevaluationpercentdifference.ToString(); i++;
            thelist[i].Value = rec.subcontractplan.ToString(); i++;
            thelist[i].Value = rec.lettercontract.ToString(); i++;
            thelist[i].Value = rec.multiyearcontract.ToString(); i++;
            thelist[i].Value = rec.performancebasedservicecontract.ToString(); i++;
            thelist[i].Value = rec.majorprogramcode.ToString(); i++;
            thelist[i].Value = rec.contingencyhumanitarianpeacekeepingoperation.ToString(); i++;
            thelist[i].Value = rec.contractfinancing.ToString(); i++;
            thelist[i].Value = rec.costorpricingdata.ToString(); i++;
            thelist[i].Value = rec.costaccountingstandardsclause.ToString(); i++;
            thelist[i].Value = rec.descriptionofcontractrequirement.ToString(); i++;
            thelist[i].Value = rec.purchasecardaspaymentmethod.ToString(); i++;
            thelist[i].Value = rec.numberofactions.ToString(); i++;
            thelist[i].Value = rec.nationalinterestactioncode.ToString(); i++;
            thelist[i].Value = rec.progsourceagency.ToString(); i++;
            thelist[i].Value = rec.progsourceaccount.ToString(); i++;
            thelist[i].Value = rec.progsourcesubacct.ToString(); i++;
            thelist[i].Value = rec.account_title.ToString(); i++;
            thelist[i].Value = rec.rec_flag.ToString(); i++;
            thelist[i].Value = rec.typeofidc.ToString(); i++;
            thelist[i].Value = rec.multipleorsingleawardidc.ToString(); i++;
            thelist[i].Value = rec.programacronym.ToString(); i++;
            thelist[i].Value = rec.vendorname.ToString(); i++;
            thelist[i].Value = rec.vendoralternatename.ToString(); i++;
            thelist[i].Value = rec.vendorlegalorganizationname.ToString(); i++;
            thelist[i].Value = rec.vendordoingasbusinessname.ToString(); i++;
            thelist[i].Value = rec.divisionname.ToString(); i++;
            thelist[i].Value = rec.divisionnumberorofficecode.ToString(); i++;
            thelist[i].Value = rec.vendorenabled.ToString(); i++;
            thelist[i].Value = rec.vendorlocationdisableflag.ToString(); i++;
            thelist[i].Value = rec.ccrexception.ToString(); i++;
            thelist[i].Value = rec.streetaddress.ToString(); i++;
            thelist[i].Value = rec.streetaddress2.ToString(); i++;
            thelist[i].Value = rec.streetaddress3.ToString(); i++;
            thelist[i].Value = rec.city.ToString(); i++;
            thelist[i].Value = rec.state.ToString(); i++;
            thelist[i].Value = rec.zipcode.ToString(); i++;
            thelist[i].Value = rec.vendorcountrycode.ToString(); i++;
            thelist[i].Value = rec.vendor_state_code.ToString(); i++;
            thelist[i].Value = rec.vendor_cd.ToString(); i++;
            thelist[i].Value = rec.congressionaldistrict.ToString(); i++;
            thelist[i].Value = rec.vendorsitecode.ToString(); i++;
            thelist[i].Value = rec.vendoralternatesitecode.ToString(); i++;
            thelist[i].Value = rec.dunsnumber.ToString(); i++;
            thelist[i].Value = rec.parentdunsnumber.ToString(); i++;
            thelist[i].Value = rec.phoneno.ToString(); i++;
            thelist[i].Value = rec.faxno.ToString(); i++;
            thelist[i].Value = rec.registrationdate.ToString(); i++;
            thelist[i].Value = rec.renewaldate.ToString(); i++;
            thelist[i].Value = rec.mod_parent.ToString(); i++;
            thelist[i].Value = rec.locationcode.ToString(); i++;
            thelist[i].Value = rec.statecode.ToString(); i++;
            thelist[i].Value = rec.placeofperformancecity.ToString(); i++;
            thelist[i].Value = rec.pop_state_code.ToString(); i++;
            thelist[i].Value = rec.placeofperformancecountrycode.ToString(); i++;
            thelist[i].Value = rec.placeofperformancezipcode.ToString(); i++;
            thelist[i].Value = rec.pop_cd.ToString(); i++;
            thelist[i].Value = rec.placeofperformancecongressionaldistrict.ToString(); i++;
            thelist[i].Value = rec.psc_cat.ToString(); i++;
            thelist[i].Value = rec.productorservicecode.ToString(); i++;
            thelist[i].Value = rec.systemequipmentcode.ToString(); i++;
            thelist[i].Value = rec.claimantprogramcode.ToString(); i++;
            thelist[i].Value = rec.principalnaicscode.ToString(); i++;
            thelist[i].Value = rec.informationtechnologycommercialitemcategory.ToString(); i++;
            thelist[i].Value = rec.gfe_gfp.ToString(); i++;
            thelist[i].Value = rec.useofepadesignatedproducts.ToString(); i++;
            thelist[i].Value = rec.recoveredmaterialclauses.ToString(); i++;
            thelist[i].Value = rec.seatransportation.ToString(); i++;
            thelist[i].Value = rec.contractbundling.ToString(); i++;
            thelist[i].Value = rec.consolidatedcontract.ToString(); i++;
            thelist[i].Value = rec.countryoforigin.ToString(); i++;
            thelist[i].Value = rec.placeofmanufacture.ToString(); i++;
            thelist[i].Value = rec.manufacturingorganizationtype.ToString(); i++;
            thelist[i].Value = rec.agencyid.ToString(); i++;
            thelist[i].Value = rec.piid.ToString(); i++;
            thelist[i].Value = rec.modnumber.ToString(); i++;
            thelist[i].Value = rec.transactionnumber.ToString(); i++;
            thelist[i].Value = rec.fiscal_year.ToString(); i++;
            thelist[i].Value = rec.idvagencyid.ToString(); i++;
            thelist[i].Value = rec.idvpiid.ToString(); i++;
            thelist[i].Value = rec.idvmodificationnumber.ToString(); i++;
            thelist[i].Value = rec.solicitationid.ToString(); i++;
            thelist[i].Value = rec.extentcompeted.ToString(); i++;
            thelist[i].Value = rec.reasonnotcompeted.ToString(); i++;
            thelist[i].Value = rec.numberofoffersreceived.ToString(); i++;
            thelist[i].Value = rec.commercialitemacquisitionprocedures.ToString(); i++;
            thelist[i].Value = rec.commercialitemtestprogram.ToString(); i++;
            thelist[i].Value = rec.smallbusinesscompetitivenessdemonstrationprogram.ToString(); i++;
            thelist[i].Value = rec.a76action.ToString(); i++;
            thelist[i].Value = rec.competitiveprocedures.ToString(); i++;
            thelist[i].Value = rec.solicitationprocedures.ToString(); i++;
            thelist[i].Value = rec.typeofsetaside.ToString(); i++;
            thelist[i].Value = rec.localareasetaside.ToString(); i++;
            thelist[i].Value = rec.evaluatedpreference.ToString(); i++;
            thelist[i].Value = rec.fedbizopps.ToString(); i++;
            thelist[i].Value = rec.research.ToString(); i++;
            thelist[i].Value = rec.statutoryexceptiontofairopportunity.ToString(); i++;
            thelist[i].Value = rec.organizationaltype.ToString(); i++;
            thelist[i].Value = rec.numberofemployees.ToString(); i++;
            thelist[i].Value = rec.annualrevenue.ToString(); i++;
            thelist[i].Value = rec.firm8aflag.ToString(); i++;
            thelist[i].Value = rec.hubzoneflag.ToString(); i++;
            thelist[i].Value = rec.sdbflag.ToString(); i++;
            thelist[i].Value = rec.issbacertifiedsmalldisadvantagedbusiness.ToString(); i++;
            thelist[i].Value = rec.shelteredworkshopflag.ToString(); i++;
            thelist[i].Value = rec.hbcuflag.ToString(); i++;
            thelist[i].Value = rec.educationalinstitutionflag.ToString(); i++;
            thelist[i].Value = rec.womenownedflag.ToString(); i++;
            thelist[i].Value = rec.veteranownedflag.ToString(); i++;
            thelist[i].Value = rec.srdvobflag.ToString(); i++;
            thelist[i].Value = rec.localgovernmentflag.ToString(); i++;
            thelist[i].Value = rec.minorityinstitutionflag.ToString(); i++;
            thelist[i].Value = rec.aiobflag.ToString(); i++;
            thelist[i].Value = rec.stategovernmentflag.ToString(); i++;
            thelist[i].Value = rec.federalgovernmentflag.ToString(); i++;
            thelist[i].Value = rec.minorityownedbusinessflag.ToString(); i++;
            thelist[i].Value = rec.apaobflag.ToString(); i++;
            thelist[i].Value = rec.tribalgovernmentflag.ToString(); i++;
            thelist[i].Value = rec.baobflag.ToString(); i++;
            thelist[i].Value = rec.naobflag.ToString(); i++;
            thelist[i].Value = rec.saaobflag.ToString(); i++;
            thelist[i].Value = rec.nonprofitorganizationflag.ToString(); i++;
            thelist[i].Value = rec.isothernotforprofitorganization.ToString(); i++;
            thelist[i].Value = rec.isforprofitorganization.ToString(); i++;
            thelist[i].Value = rec.isfoundation.ToString(); i++;
            thelist[i].Value = rec.haobflag.ToString(); i++;
            thelist[i].Value = rec.ishispanicservicinginstitution.ToString(); i++;
            thelist[i].Value = rec.emergingsmallbusinessflag.ToString(); i++;
            thelist[i].Value = rec.hospitalflag.ToString(); i++;
            thelist[i].Value = rec.contractingofficerbusinesssizedetermination.ToString(); i++;
            thelist[i].Value = rec.is1862landgrantcollege.ToString(); i++;
            thelist[i].Value = rec.is1890landgrantcollege.ToString(); i++;
            thelist[i].Value = rec.is1994landgrantcollege.ToString(); i++;
            thelist[i].Value = rec.isveterinarycollege.ToString(); i++;
            thelist[i].Value = rec.isveterinaryhospital.ToString(); i++;
            thelist[i].Value = rec.isprivateuniversityorcollege.ToString(); i++;
            thelist[i].Value = rec.isschoolofforestry.ToString(); i++;
            thelist[i].Value = rec.isstatecontrolledinstitutionofhigherlearning.ToString(); i++;
            thelist[i].Value = rec.isserviceprovider.ToString(); i++;
            thelist[i].Value = rec.receivescontracts.ToString(); i++;
            thelist[i].Value = rec.receivesgrants.ToString(); i++;
            thelist[i].Value = rec.receivescontractsandgrants.ToString(); i++;
            thelist[i].Value = rec.isairportauthority.ToString(); i++;
            thelist[i].Value = rec.iscouncilofgovernments.ToString(); i++;
            thelist[i].Value = rec.ishousingauthoritiespublicortribal.ToString(); i++;
            thelist[i].Value = rec.isinterstateentity.ToString(); i++;
            thelist[i].Value = rec.isplanningcommission.ToString(); i++;
            thelist[i].Value = rec.isportauthority.ToString(); i++;
            thelist[i].Value = rec.istransitauthority.ToString(); i++;
            thelist[i].Value = rec.issubchapterscorporation.ToString(); i++;
            thelist[i].Value = rec.islimitedliabilitycorporation.ToString(); i++;
            thelist[i].Value = rec.isforeignownedandlocated.ToString(); i++;
            thelist[i].Value = rec.isarchitectureandengineering.ToString(); i++;
            thelist[i].Value = rec.isdotcertifieddisadvantagedbusinessenterprise.ToString(); i++;
            thelist[i].Value = rec.iscitylocalgovernment.ToString(); i++;
            thelist[i].Value = rec.iscommunitydevelopedcorporationownedfirm.ToString(); i++;
            thelist[i].Value = rec.iscommunitydevelopmentcorporation.ToString(); i++;
            thelist[i].Value = rec.isconstructionfirm.ToString(); i++;
            thelist[i].Value = rec.ismanufacturerofgoods.ToString(); i++;
            thelist[i].Value = rec.iscorporateentitynottaxexempt.ToString(); i++;
            thelist[i].Value = rec.iscountylocalgovernment.ToString(); i++;
            thelist[i].Value = rec.isdomesticshelter.ToString(); i++;
            thelist[i].Value = rec.isfederalgovernmentagency.ToString(); i++;
            thelist[i].Value = rec.isfederallyfundedresearchanddevelopmentcorp.ToString(); i++;
            thelist[i].Value = rec.isforeigngovernment.ToString(); i++;
            thelist[i].Value = rec.isindiantribe.ToString(); i++;
            thelist[i].Value = rec.isintermunicipallocalgovernment.ToString(); i++;
            thelist[i].Value = rec.isinternationalorganization.ToString(); i++;
            thelist[i].Value = rec.islaborsurplusareafirm.ToString(); i++;
            thelist[i].Value = rec.islocalgovernmentowned.ToString(); i++;
            thelist[i].Value = rec.ismunicipalitylocalgovernment.ToString(); i++;
            thelist[i].Value = rec.isnativehawaiianownedorganizationorfirm.ToString(); i++;
            thelist[i].Value = rec.isotherbusinessororganization.ToString(); i++;
            thelist[i].Value = rec.isotherminorityowned.ToString(); i++;
            thelist[i].Value = rec.ispartnershiporlimitedliabilitypartnership.ToString(); i++;
            thelist[i].Value = rec.isschooldistrictlocalgovernment.ToString(); i++;
            thelist[i].Value = rec.issmallagriculturalcooperative.ToString(); i++;
            thelist[i].Value = rec.issoleproprietorship.ToString(); i++;
            thelist[i].Value = rec.istownshiplocalgovernment.ToString(); i++;
            thelist[i].Value = rec.istriballyownedfirm.ToString(); i++;
            thelist[i].Value = rec.istribalcollege.ToString(); i++;
            thelist[i].Value = rec.isalaskannativeownedcorporationorfirm.ToString(); i++;
            thelist[i].Value = rec.iscorporateentitytaxexempt.ToString(); i++;
            thelist[i].Value = rec.iswomenownedsmallbusiness.ToString(); i++;
            thelist[i].Value = rec.isecondisadvwomenownedsmallbusiness.ToString(); i++;
            thelist[i].Value = rec.isjointventurewomenownedsmallbusiness.ToString(); i++;
            thelist[i].Value = rec.isjointventureecondisadvwomenownedsmallbusiness.ToString(); i++;
            thelist[i].Value = rec.walshhealyact.ToString(); i++;
            thelist[i].Value = rec.servicecontractact.ToString(); i++;
            thelist[i].Value = rec.davisbaconact.ToString(); i++;
            thelist[i].Value = rec.clingercohenact.ToString(); i++;
            thelist[i].Value = rec.otherstatutoryauthority.ToString(); i++;
            thelist[i].Value = rec.prime_awardee_executive1.ToString(); i++;
            thelist[i].Value = rec.prime_awardee_executive1_compensation.ToString(); i++;
            thelist[i].Value = rec.prime_awardee_executive2.ToString(); i++;
            thelist[i].Value = rec.prime_awardee_executive2_compensation.ToString(); i++;
            thelist[i].Value = rec.prime_awardee_executive3.ToString(); i++;
            thelist[i].Value = rec.prime_awardee_executive3_compensation.ToString(); i++;
            thelist[i].Value = rec.prime_awardee_executive4.ToString(); i++;
            thelist[i].Value = rec.prime_awardee_executive4_compensation.ToString(); i++;
            thelist[i].Value = rec.prime_awardee_executive5.ToString(); i++;
            thelist[i].Value = rec.prime_awardee_executive5_compensation.ToString(); i++;
            thelist[i].Value = rec.interagencycontractingauthority.ToString(); i++;
            thelist[i].Value = rec.last_modified_date.ToString(); i++;
            if (rec.contract_vehicle == null)
                i++;
            else
            {
                thelist[i].Value = rec.contract_vehicle.ToString(); i++;
            }
            if (rec.work == null)

                i++;
            else
            {
                thelist[i].Value = rec.work.ToString(); i++;
            }
            if (rec.completion_date == null)
                i++;
            else
            {
                thelist[i].Value = rec.completion_date.ToString(); i++;
            }
            if (rec.completion_year == null)

                i++;
            else
            {
                thelist[i].Value = rec.completion_year.ToString(); i++;
            }
            thelist[i].Value = rec.insert_date.ToString(); i++;
            thelist[i].Value = rec.insert_user.ToString();




            return thelist;
        }

        public static ObservableCollection<ComboBoxDisplayValue> GetyearCB()
        {

            using (USAspendEF ef = new USAspendEF())
            {

                var year = from a in ef.GUIconfig
                           where a.combobox == 1
                           orderby a.value descending
                           select a;
                ObservableCollection<ComboBoxDisplayValue> yearitems = new ObservableCollection<ComboBoxDisplayValue>();
                foreach (var yearcb in year)
                {
                    yearitems.Add(new ComboBoxDisplayValue(yearcb.display, yearcb.value));

                }

                return yearitems;
            }
        }
        public static ObservableCollection<ComboBoxDisplayValue> GetagencyCB()
        {

            using (USAspendEF ef = new USAspendEF())
            {

                var agency = from a in ef.GUIconfig
                           where a.combobox == 0
                           orderby a.value 
                           select a;
                ObservableCollection<ComboBoxDisplayValue> agencyitems = new ObservableCollection<ComboBoxDisplayValue>();
                foreach (var agencycb in agency)
                {
                    agencyitems.Add(new ComboBoxDisplayValue(agencycb.display, agencycb.value));

                }

                return agencyitems;
            }
        }


        public static Current_usaspend ConvertOOStoUSASpend(OutOfScope_usaspend rec)
        {
            if (rec == null)
                return null;
            Current_usaspend arec = new Current_usaspend();

          arec.unique_transaction_id = rec.unique_transaction_id;
          arec.transaction_status     =          rec.transaction_status;
          arec.dollarsobligated        =       rec.dollarsobligated;
         arec.baseandexercisedoptionsvalue    =          rec.baseandexercisedoptionsvalue;
          arec.baseandalloptionsvalue       =       rec.baseandalloptionsvalue;
          arec.maj_agency_cat       =       rec.maj_agency_cat;
          arec.mod_agency         =      rec.mod_agency;
          arec.maj_fund_agency_cat    =          rec.maj_fund_agency_cat;
          arec.contractingofficeagencyid  =             rec.contractingofficeagencyid;
          arec.contractingofficeid      =          rec.contractingofficeid;
          arec.fundingrequestingagencyid     =         rec.fundingrequestingagencyid;
          arec.fundingrequestingofficeid =               rec.fundingrequestingofficeid;
          arec.fundedbyforeignentity        =    rec.fundedbyforeignentity;
          arec.signeddate            =  rec.signeddate;
          arec.effectivedate          =     rec.effectivedate;
          arec.currentcompletiondate   =            rec.currentcompletiondate;
           arec.ultimatecompletiondate  =             rec.ultimatecompletiondate;
          arec.lastdatetoorder           =    rec.lastdatetoorder;
          arec.contractactiontype         =      rec.contractactiontype;
          arec.reasonformodification       =        rec.reasonformodification;
          arec.typeofcontractpricing        =       rec.typeofcontractpricing;
          arec.priceevaluationpercentdifference =              rec.priceevaluationpercentdifference;
          arec.subcontractplan         =      rec.subcontractplan;
          arec.lettercontract           =    rec.lettercontract;
          arec.multiyearcontract         =      rec.multiyearcontract;
          arec.performancebasedservicecontract =              rec.performancebasedservicecontract;
          arec.majorprogramcode            =   rec.majorprogramcode;
          arec.contingencyhumanitarianpeacekeepingoperation    =           rec.contingencyhumanitarianpeacekeepingoperation;
          arec.contractfinancing           =    rec.contractfinancing;
          arec.costorpricingdata            =   rec.costorpricingdata;
          arec.costaccountingstandardsclause  =             rec.costaccountingstandardsclause;
          arec.descriptionofcontractrequirement =              rec.descriptionofcontractrequirement;
          arec.purchasecardaspaymentmethod       =        rec.purchasecardaspaymentmethod;
          arec.numberofactions             =  rec.numberofactions;
          arec.nationalinterestactioncode   =            rec.nationalinterestactioncode;
          arec.progsourceagency           =    rec.progsourceagency;
          arec.progsourceaccount           =    rec.progsourceaccount;
          arec.progsourcesubacct           =    rec.progsourcesubacct;
          arec.account_title          =     rec.account_title;
          arec.rec_flag            =   rec.rec_flag;
          arec.typeofidc            =   rec.typeofidc;
          arec.multipleorsingleawardidc   =            rec.multipleorsingleawardidc;
          arec.programacronym            =   rec.programacronym;
          arec.vendorname            =   rec.vendorname;
          arec.vendoralternatename    =           rec.vendoralternatename;
          arec.vendorlegalorganizationname   =            rec.vendorlegalorganizationname;
          arec.vendordoingasbusinessname      =         rec.vendordoingasbusinessname;
          arec.divisionname           =    rec.divisionname;
          arec.divisionnumberorofficecode =              rec.divisionnumberorofficecode;
          arec.vendorenabled            =   rec.vendorenabled;
          arec.vendorlocationdisableflag =              rec.vendorlocationdisableflag;
          arec.ccrexception             =  rec.ccrexception;
          arec.streetaddress             =  rec.streetaddress;
          arec.streetaddress2             =  rec.streetaddress2;
          arec.streetaddress3          =     rec.streetaddress3;
          arec.city            =   rec.city;
          arec.state            =   rec.state;
          arec.zipcode           =    rec.zipcode;
          arec.vendorcountrycode  =             rec.vendorcountrycode;
          arec.vendor_state_code   =            rec.vendor_state_code;
          arec.vendor_cd            =   rec.vendor_cd;
          arec.congressionaldistrict =              rec.congressionaldistrict;
          arec.vendorsitecode         =      rec.vendorsitecode;
          arec.vendoralternatesitecode =              rec.vendoralternatesitecode;
          arec.dunsnumber           =    rec.dunsnumber;
          arec.parentdunsnumber      =         rec.parentdunsnumber;
          arec.phoneno          =     rec.phoneno;
          arec.faxno             =  rec.faxno;
          arec.registrationdate   =            rec.registrationdate;
          arec.renewaldate         =      rec.renewaldate;
          arec.mod_parent           =    rec.mod_parent;
          arec.locationcode          =     rec.locationcode;
          arec.statecode              = rec.statecode;
          arec.placeofperformancecity   =            rec.placeofperformancecity;
          arec.pop_state_code           =    rec.pop_state_code;
          arec.placeofperformancecountrycode   =            rec.placeofperformancecountrycode;
          arec.placeofperformancezipcode        =       rec.placeofperformancezipcode;
          arec.pop_cd           =    rec.pop_cd;
          arec.placeofperformancecongressionaldistrict   =            rec.placeofperformancecongressionaldistrict;
          arec.psc_cat             =  rec.psc_cat;
          arec.productorservicecode   =            rec.productorservicecode;
          arec.systemequipmentcode     =          rec.systemequipmentcode;
          arec.claimantprogramcode      =         rec.claimantprogramcode;
          arec.principalnaicscode        =       rec.principalnaicscode;
          arec.informationtechnologycommercialitemcategory      =         rec.informationtechnologycommercialitemcategory;
          arec.gfe_gfp       =        rec.gfe_gfp;
          arec.useofepadesignatedproducts    =           rec.useofepadesignatedproducts;
          arec.recoveredmaterialclauses       =        rec.recoveredmaterialclauses;
          arec.seatransportation          =     rec.seatransportation;
          arec.contractbundling            =   rec.contractbundling;
          arec.consolidatedcontract         =      rec.consolidatedcontract;
          arec.countryoforigin          =     rec.countryoforigin;
          arec.placeofmanufacture        =       rec.placeofmanufacture;
          arec.manufacturingorganizationtype  =             rec.manufacturingorganizationtype;
          arec.agencyid          =     rec.agencyid;
          arec.piid          =     rec.piid;
          arec.modnumber      =         rec.modnumber;
          arec.transactionnumber   =            rec.transactionnumber;
          arec.fiscal_year          =     rec.fiscal_year;
          arec.idvagencyid           =    rec.idvagencyid;
          arec.idvpiid         =      rec.idvpiid;
          arec.idvmodificationnumber  =             rec.idvmodificationnumber;
          arec.solicitationid          =     rec.solicitationid;
          arec.extentcompeted           =    rec.extentcompeted;
          arec.reasonnotcompeted         =      rec.reasonnotcompeted;
          arec.numberofoffersreceived     =          rec.numberofoffersreceived;
          arec.commercialitemacquisitionprocedures     =          rec.commercialitemacquisitionprocedures;
          arec.commercialitemtestprogram            =   rec.commercialitemtestprogram;
          arec.smallbusinesscompetitivenessdemonstrationprogram        =       rec.smallbusinesscompetitivenessdemonstrationprogram;
          arec.a76action       =        rec.a76action;
          arec.competitiveprocedures        =       rec.competitiveprocedures;
          arec.solicitationprocedures        =       rec.solicitationprocedures;
          arec.typeofsetaside          =     rec.typeofsetaside;
          arec.localareasetaside        =       rec.localareasetaside;
          arec.evaluatedpreference       =        rec.evaluatedpreference;
          arec.fedbizopps        =       rec.fedbizopps;
          arec.research           =    rec.research;
          arec.statutoryexceptiontofairopportunity    =           rec.statutoryexceptiontofairopportunity;
          arec.organizationaltype         =      rec.organizationaltype;
          arec.numberofemployees           =    rec.numberofemployees;
          arec.annualrevenue      =         rec.annualrevenue;
          arec.firm8aflag          =     rec.firm8aflag;
          arec.hubzoneflag          =     rec.hubzoneflag;
          arec.sdbflag         =      rec.sdbflag;
          arec.issbacertifiedsmalldisadvantagedbusiness   =            rec.issbacertifiedsmalldisadvantagedbusiness;
          arec.shelteredworkshopflag          =     rec.shelteredworkshopflag;
          arec.hbcuflag           =    rec.hbcuflag;
          arec.educationalinstitutionflag    =           rec.educationalinstitutionflag;
          arec.womenownedflag         =      rec.womenownedflag;
          arec.veteranownedflag        =       rec.veteranownedflag;
          arec.srdvobflag         =      rec.srdvobflag;
          arec.localgovernmentflag    =           rec.localgovernmentflag;
          arec.minorityinstitutionflag    =           rec.minorityinstitutionflag;
          arec.aiobflag         =      rec.aiobflag;
          arec.stategovernmentflag    =           rec.stategovernmentflag;
          arec.federalgovernmentflag   =            rec.federalgovernmentflag;
          arec.minorityownedbusinessflag     =          rec.minorityownedbusinessflag;
          arec.apaobflag         =      rec.apaobflag;
          arec.tribalgovernmentflag      =         rec.tribalgovernmentflag;
          arec.baobflag          =     rec.baobflag;
          arec.naobflag           =    rec.naobflag;
          arec.saaobflag          =     rec.saaobflag;
          arec.nonprofitorganizationflag    =           rec.nonprofitorganizationflag;
          arec.isothernotforprofitorganization   =            rec.isothernotforprofitorganization;
          arec.isforprofitorganization          =     rec.isforprofitorganization;
          arec.isfoundation       =        rec.isfoundation;
          arec.haobflag           =    rec.haobflag;
          arec.ishispanicservicinginstitution      =         rec.ishispanicservicinginstitution;
          arec.emergingsmallbusinessflag           =    rec.emergingsmallbusinessflag;
          arec.hospitalflag          =     rec.hospitalflag;
          arec.contractingofficerbusinesssizedetermination   =            rec.contractingofficerbusinesssizedetermination;
          arec.is1862landgrantcollege         =      rec.is1862landgrantcollege;
          arec.is1890landgrantcollege          =     rec.is1890landgrantcollege;
          arec.is1994landgrantcollege          =     rec.is1994landgrantcollege;
          arec.isveterinarycollege           =    rec.isveterinarycollege;
          arec.isveterinaryhospital           =    rec.isveterinaryhospital;
          arec.isprivateuniversityorcollege    =           rec.isprivateuniversityorcollege;
          arec.isschoolofforestry           =    rec.isschoolofforestry;
          arec.isstatecontrolledinstitutionofhigherlearning  =             rec.isstatecontrolledinstitutionofhigherlearning;
          arec.isserviceprovider           =    rec.isserviceprovider;
          arec.receivescontracts            =   rec.receivescontracts;
          arec.receivesgrants           =    rec.receivesgrants;
          arec.receivescontractsandgrants   =            rec.receivescontractsandgrants;
          arec.isairportauthority          =     rec.isairportauthority;
          arec.iscouncilofgovernments       =        rec.iscouncilofgovernments;
          arec.ishousingauthoritiespublicortribal    =           rec.ishousingauthoritiespublicortribal;
          arec.isinterstateentity         =      rec.isinterstateentity;
          arec.isplanningcommission        =       rec.isplanningcommission;
          arec.isportauthority          =     rec.isportauthority;
         arec.istransitauthority         =      rec.istransitauthority;
          arec.issubchapterscorporation   =            rec.issubchapterscorporation;
          arec.islimitedliabilitycorporation   =            rec.islimitedliabilitycorporation;
          arec.isforeignownedandlocated         =      rec.isforeignownedandlocated;
          arec.isarchitectureandengineering      =         rec.isarchitectureandengineering;
          arec.isdotcertifieddisadvantagedbusinessenterprise      =         rec.isdotcertifieddisadvantagedbusinessenterprise;
          arec.iscitylocalgovernment        =       rec.iscitylocalgovernment;
          arec.iscommunitydevelopedcorporationownedfirm   =            rec.iscommunitydevelopedcorporationownedfirm;
          arec.iscommunitydevelopmentcorporation           =    rec.iscommunitydevelopmentcorporation;
          arec.isconstructionfirm         =      rec.isconstructionfirm;
          arec.ismanufacturerofgoods       =        rec.ismanufacturerofgoods;
          arec.iscorporateentitynottaxexempt    =           rec.iscorporateentitynottaxexempt;
          arec.iscountylocalgovernment         =      rec.iscountylocalgovernment;
          arec.isdomesticshelter         =      rec.isdomesticshelter;
          arec.isfederalgovernmentagency     =          rec.isfederalgovernmentagency;
          arec.isfederallyfundedresearchanddevelopmentcorp        =       rec.isfederallyfundedresearchanddevelopmentcorp;
          arec.isforeigngovernment        =       rec.isforeigngovernment;
          arec.isindiantribe          =     rec.isindiantribe;
          arec.isintermunicipallocalgovernment      =         rec.isintermunicipallocalgovernment;
          arec.isinternationalorganization         =      rec.isinternationalorganization;
          arec.islaborsurplusareafirm          =     rec.islaborsurplusareafirm;
          arec.islocalgovernmentowned           =    rec.islocalgovernmentowned;
          arec.ismunicipalitylocalgovernment     =          rec.ismunicipalitylocalgovernment;
          arec.isnativehawaiianownedorganizationorfirm       =        rec.isnativehawaiianownedorganizationorfirm;
          arec.isotherbusinessororganization          =     rec.isotherbusinessororganization;
          arec.isotherminorityowned        =       rec.isotherminorityowned;
          arec.ispartnershiporlimitedliabilitypartnership   =            rec.ispartnershiporlimitedliabilitypartnership;
          arec.isschooldistrictlocalgovernment      =         rec.isschooldistrictlocalgovernment;
          arec.issmallagriculturalcooperative        =       rec.issmallagriculturalcooperative;
          arec.issoleproprietorship         =      rec.issoleproprietorship;
          arec.istownshiplocalgovernment     =          rec.istownshiplocalgovernment;
          arec.istriballyownedfirm           =    rec.istriballyownedfirm;
          arec.istribalcollege          =     rec.istribalcollege;
          arec.isalaskannativeownedcorporationorfirm    =           rec.isalaskannativeownedcorporationorfirm;
          arec.iscorporateentitytaxexempt        =       rec.iscorporateentitytaxexempt;
          arec.iswomenownedsmallbusiness          =     rec.iswomenownedsmallbusiness;
          arec.isecondisadvwomenownedsmallbusiness     =          rec.isecondisadvwomenownedsmallbusiness;
          arec.isjointventurewomenownedsmallbusiness    =           rec.isjointventurewomenownedsmallbusiness;
          arec.isjointventureecondisadvwomenownedsmallbusiness     =          rec.isjointventureecondisadvwomenownedsmallbusiness;
          arec.walshhealyact         =      rec.walshhealyact;
          arec.servicecontractact     =          rec.servicecontractact;
          arec.davisbaconact          =     rec.davisbaconact;
          arec.clingercohenact        =       rec.clingercohenact;
          arec.otherstatutoryauthority    =           rec.otherstatutoryauthority;
          arec.prime_awardee_executive1    =           rec.prime_awardee_executive1;
          arec.prime_awardee_executive1_compensation       =        rec.prime_awardee_executive1_compensation;
          arec.prime_awardee_executive2          =     rec.prime_awardee_executive2;
          arec.prime_awardee_executive2_compensation     =          rec.prime_awardee_executive2_compensation;
          arec.prime_awardee_executive3       =        rec.prime_awardee_executive3;
          arec.prime_awardee_executive3_compensation       =        rec.prime_awardee_executive3_compensation;
          arec.prime_awardee_executive4         =      rec.prime_awardee_executive4;
          arec.prime_awardee_executive4_compensation     =          rec.prime_awardee_executive4_compensation;
          arec.prime_awardee_executive5       =        rec.prime_awardee_executive5;
          arec.prime_awardee_executive5_compensation      =         rec.prime_awardee_executive5_compensation;
          arec.interagencycontractingauthority      =         rec.interagencycontractingauthority;
          arec.last_modified_date    =           rec.last_modified_date;
            if (rec.contract_vehicle == null)
                arec.contract_vehicle= String.Empty;
            else
            {
                arec.contract_vehicle= rec.contract_vehicle;
            }
            if (rec.work == null)

                arec.work =  String.Empty;
            else
            {
                arec.work= rec.work;
            }
            if (rec.completion_date == null)
                arec.completion_date = null;
            else
            {
              arec.completion_date = rec.completion_date;
            }
            if (rec.completion_year == null)

                arec.completion_year = String.Empty;
            else
            {
             arec.completion_year = rec.completion_year;
            }
            // "\"" +  rec.contract_vehicle.ToString() + "\""  +  "," +
            // "\"" +  rec.work.ToString() + "\""  +  "," +
            // "\"" +  rec.completion_date.ToString() + "\""  +  "," +
            // "\"" +  rec.completion_year.ToString() + "\""  +  "," +
           arec.insert_date= rec.insert_date;
             arec.insert_user= rec.insert_user;
             return arec;
        }

         public static OutOfScope_usaspend ConvertUSASpendtoOOS(Current_usaspend rec)
        {
            if (rec == null)
                return null;
            OutOfScope_usaspend arec = new OutOfScope_usaspend();

          arec.unique_transaction_id = rec.unique_transaction_id;
          arec.transaction_status     =          rec.transaction_status;
          arec.dollarsobligated        =       rec.dollarsobligated;
         arec.baseandexercisedoptionsvalue    =          rec.baseandexercisedoptionsvalue;
          arec.baseandalloptionsvalue       =       rec.baseandalloptionsvalue;
          arec.maj_agency_cat       =       rec.maj_agency_cat;
          arec.mod_agency         =      rec.mod_agency;
          arec.maj_fund_agency_cat    =          rec.maj_fund_agency_cat;
          arec.contractingofficeagencyid  =             rec.contractingofficeagencyid;
          arec.contractingofficeid      =          rec.contractingofficeid;
          arec.fundingrequestingagencyid     =         rec.fundingrequestingagencyid;
          arec.fundingrequestingofficeid =               rec.fundingrequestingofficeid;
          arec.fundedbyforeignentity        =    rec.fundedbyforeignentity;
          arec.signeddate            =  rec.signeddate;
          arec.effectivedate          =     rec.effectivedate;
          arec.currentcompletiondate   =            rec.currentcompletiondate;
           arec.ultimatecompletiondate  =             rec.ultimatecompletiondate;
          arec.lastdatetoorder           =    rec.lastdatetoorder;
          arec.contractactiontype         =      rec.contractactiontype;
          arec.reasonformodification       =        rec.reasonformodification;
          arec.typeofcontractpricing        =       rec.typeofcontractpricing;
          arec.priceevaluationpercentdifference =              rec.priceevaluationpercentdifference;
          arec.subcontractplan         =      rec.subcontractplan;
          arec.lettercontract           =    rec.lettercontract;
          arec.multiyearcontract         =      rec.multiyearcontract;
          arec.performancebasedservicecontract =              rec.performancebasedservicecontract;
          arec.majorprogramcode            =   rec.majorprogramcode;
          arec.contingencyhumanitarianpeacekeepingoperation    =           rec.contingencyhumanitarianpeacekeepingoperation;
          arec.contractfinancing           =    rec.contractfinancing;
          arec.costorpricingdata            =   rec.costorpricingdata;
          arec.costaccountingstandardsclause  =             rec.costaccountingstandardsclause;
          arec.descriptionofcontractrequirement =              rec.descriptionofcontractrequirement;
          arec.purchasecardaspaymentmethod       =        rec.purchasecardaspaymentmethod;
          arec.numberofactions             =  rec.numberofactions;
          arec.nationalinterestactioncode   =            rec.nationalinterestactioncode;
          arec.progsourceagency           =    rec.progsourceagency;
          arec.progsourceaccount           =    rec.progsourceaccount;
          arec.progsourcesubacct           =    rec.progsourcesubacct;
          arec.account_title          =     rec.account_title;
          arec.rec_flag            =   rec.rec_flag;
          arec.typeofidc            =   rec.typeofidc;
          arec.multipleorsingleawardidc   =            rec.multipleorsingleawardidc;
          arec.programacronym            =   rec.programacronym;
          arec.vendorname            =   rec.vendorname;
          arec.vendoralternatename    =           rec.vendoralternatename;
          arec.vendorlegalorganizationname   =            rec.vendorlegalorganizationname;
          arec.vendordoingasbusinessname      =         rec.vendordoingasbusinessname;
          arec.divisionname           =    rec.divisionname;
          arec.divisionnumberorofficecode =              rec.divisionnumberorofficecode;
          arec.vendorenabled            =   rec.vendorenabled;
          arec.vendorlocationdisableflag =              rec.vendorlocationdisableflag;
          arec.ccrexception             =  rec.ccrexception;
          arec.streetaddress             =  rec.streetaddress;
          arec.streetaddress2             =  rec.streetaddress2;
          arec.streetaddress3          =     rec.streetaddress3;
          arec.city            =   rec.city;
          arec.state            =   rec.state;
          arec.zipcode           =    rec.zipcode;
          arec.vendorcountrycode  =             rec.vendorcountrycode;
          arec.vendor_state_code   =            rec.vendor_state_code;
          arec.vendor_cd            =   rec.vendor_cd;
          arec.congressionaldistrict =              rec.congressionaldistrict;
          arec.vendorsitecode         =      rec.vendorsitecode;
          arec.vendoralternatesitecode =              rec.vendoralternatesitecode;
          arec.dunsnumber           =    rec.dunsnumber;
          arec.parentdunsnumber      =         rec.parentdunsnumber;
          arec.phoneno          =     rec.phoneno;
          arec.faxno             =  rec.faxno;
          arec.registrationdate   =            rec.registrationdate;
          arec.renewaldate         =      rec.renewaldate;
          arec.mod_parent           =    rec.mod_parent;
          arec.locationcode          =     rec.locationcode;
          arec.statecode              = rec.statecode;
          arec.placeofperformancecity   =            rec.placeofperformancecity;
          arec.pop_state_code           =    rec.pop_state_code;
          arec.placeofperformancecountrycode   =            rec.placeofperformancecountrycode;
          arec.placeofperformancezipcode        =       rec.placeofperformancezipcode;
          arec.pop_cd           =    rec.pop_cd;
          arec.placeofperformancecongressionaldistrict   =            rec.placeofperformancecongressionaldistrict;
          arec.psc_cat             =  rec.psc_cat;
          arec.productorservicecode   =            rec.productorservicecode;
          arec.systemequipmentcode     =          rec.systemequipmentcode;
          arec.claimantprogramcode      =         rec.claimantprogramcode;
          arec.principalnaicscode        =       rec.principalnaicscode;
          arec.informationtechnologycommercialitemcategory      =         rec.informationtechnologycommercialitemcategory;
          arec.gfe_gfp       =        rec.gfe_gfp;
          arec.useofepadesignatedproducts    =           rec.useofepadesignatedproducts;
          arec.recoveredmaterialclauses       =        rec.recoveredmaterialclauses;
          arec.seatransportation          =     rec.seatransportation;
          arec.contractbundling            =   rec.contractbundling;
          arec.consolidatedcontract         =      rec.consolidatedcontract;
          arec.countryoforigin          =     rec.countryoforigin;
          arec.placeofmanufacture        =       rec.placeofmanufacture;
          arec.manufacturingorganizationtype  =             rec.manufacturingorganizationtype;
          arec.agencyid          =     rec.agencyid;
          arec.piid          =     rec.piid;
          arec.modnumber      =         rec.modnumber;
          arec.transactionnumber   =            rec.transactionnumber;
          arec.fiscal_year          =     rec.fiscal_year;
          arec.idvagencyid           =    rec.idvagencyid;
          arec.idvpiid         =      rec.idvpiid;
          arec.idvmodificationnumber  =             rec.idvmodificationnumber;
          arec.solicitationid          =     rec.solicitationid;
          arec.extentcompeted           =    rec.extentcompeted;
          arec.reasonnotcompeted         =      rec.reasonnotcompeted;
          arec.numberofoffersreceived     =          rec.numberofoffersreceived;
          arec.commercialitemacquisitionprocedures     =          rec.commercialitemacquisitionprocedures;
          arec.commercialitemtestprogram            =   rec.commercialitemtestprogram;
          arec.smallbusinesscompetitivenessdemonstrationprogram        =       rec.smallbusinesscompetitivenessdemonstrationprogram;
          arec.a76action       =        rec.a76action;
          arec.competitiveprocedures        =       rec.competitiveprocedures;
          arec.solicitationprocedures        =       rec.solicitationprocedures;
          arec.typeofsetaside          =     rec.typeofsetaside;
          arec.localareasetaside        =       rec.localareasetaside;
          arec.evaluatedpreference       =        rec.evaluatedpreference;
          arec.fedbizopps        =       rec.fedbizopps;
          arec.research           =    rec.research;
          arec.statutoryexceptiontofairopportunity    =           rec.statutoryexceptiontofairopportunity;
          arec.organizationaltype         =      rec.organizationaltype;
          arec.numberofemployees           =    rec.numberofemployees;
          arec.annualrevenue      =         rec.annualrevenue;
          arec.firm8aflag          =     rec.firm8aflag;
          arec.hubzoneflag          =     rec.hubzoneflag;
          arec.sdbflag         =      rec.sdbflag;
          arec.issbacertifiedsmalldisadvantagedbusiness   =            rec.issbacertifiedsmalldisadvantagedbusiness;
          arec.shelteredworkshopflag          =     rec.shelteredworkshopflag;
          arec.hbcuflag           =    rec.hbcuflag;
          arec.educationalinstitutionflag    =           rec.educationalinstitutionflag;
          arec.womenownedflag         =      rec.womenownedflag;
          arec.veteranownedflag        =       rec.veteranownedflag;
          arec.srdvobflag         =      rec.srdvobflag;
          arec.localgovernmentflag    =           rec.localgovernmentflag;
          arec.minorityinstitutionflag    =           rec.minorityinstitutionflag;
          arec.aiobflag         =      rec.aiobflag;
          arec.stategovernmentflag    =           rec.stategovernmentflag;
          arec.federalgovernmentflag   =            rec.federalgovernmentflag;
          arec.minorityownedbusinessflag     =          rec.minorityownedbusinessflag;
          arec.apaobflag         =      rec.apaobflag;
          arec.tribalgovernmentflag      =         rec.tribalgovernmentflag;
          arec.baobflag          =     rec.baobflag;
          arec.naobflag           =    rec.naobflag;
          arec.saaobflag          =     rec.saaobflag;
          arec.nonprofitorganizationflag    =           rec.nonprofitorganizationflag;
          arec.isothernotforprofitorganization   =            rec.isothernotforprofitorganization;
          arec.isforprofitorganization          =     rec.isforprofitorganization;
          arec.isfoundation       =        rec.isfoundation;
          arec.haobflag           =    rec.haobflag;
          arec.ishispanicservicinginstitution      =         rec.ishispanicservicinginstitution;
          arec.emergingsmallbusinessflag           =    rec.emergingsmallbusinessflag;
          arec.hospitalflag          =     rec.hospitalflag;
          arec.contractingofficerbusinesssizedetermination   =            rec.contractingofficerbusinesssizedetermination;
          arec.is1862landgrantcollege         =      rec.is1862landgrantcollege;
          arec.is1890landgrantcollege          =     rec.is1890landgrantcollege;
          arec.is1994landgrantcollege          =     rec.is1994landgrantcollege;
          arec.isveterinarycollege           =    rec.isveterinarycollege;
          arec.isveterinaryhospital           =    rec.isveterinaryhospital;
          arec.isprivateuniversityorcollege    =           rec.isprivateuniversityorcollege;
          arec.isschoolofforestry           =    rec.isschoolofforestry;
          arec.isstatecontrolledinstitutionofhigherlearning  =             rec.isstatecontrolledinstitutionofhigherlearning;
          arec.isserviceprovider           =    rec.isserviceprovider;
          arec.receivescontracts            =   rec.receivescontracts;
          arec.receivesgrants           =    rec.receivesgrants;
          arec.receivescontractsandgrants   =            rec.receivescontractsandgrants;
          arec.isairportauthority          =     rec.isairportauthority;
          arec.iscouncilofgovernments       =        rec.iscouncilofgovernments;
          arec.ishousingauthoritiespublicortribal    =           rec.ishousingauthoritiespublicortribal;
          arec.isinterstateentity         =      rec.isinterstateentity;
          arec.isplanningcommission        =       rec.isplanningcommission;
          arec.isportauthority          =     rec.isportauthority;
         arec.istransitauthority         =      rec.istransitauthority;
          arec.issubchapterscorporation   =            rec.issubchapterscorporation;
          arec.islimitedliabilitycorporation   =            rec.islimitedliabilitycorporation;
          arec.isforeignownedandlocated         =      rec.isforeignownedandlocated;
          arec.isarchitectureandengineering      =         rec.isarchitectureandengineering;
          arec.isdotcertifieddisadvantagedbusinessenterprise      =         rec.isdotcertifieddisadvantagedbusinessenterprise;
          arec.iscitylocalgovernment        =       rec.iscitylocalgovernment;
          arec.iscommunitydevelopedcorporationownedfirm   =            rec.iscommunitydevelopedcorporationownedfirm;
          arec.iscommunitydevelopmentcorporation           =    rec.iscommunitydevelopmentcorporation;
          arec.isconstructionfirm         =      rec.isconstructionfirm;
          arec.ismanufacturerofgoods       =        rec.ismanufacturerofgoods;
          arec.iscorporateentitynottaxexempt    =           rec.iscorporateentitynottaxexempt;
          arec.iscountylocalgovernment         =      rec.iscountylocalgovernment;
          arec.isdomesticshelter         =      rec.isdomesticshelter;
          arec.isfederalgovernmentagency     =          rec.isfederalgovernmentagency;
          arec.isfederallyfundedresearchanddevelopmentcorp        =       rec.isfederallyfundedresearchanddevelopmentcorp;
          arec.isforeigngovernment        =       rec.isforeigngovernment;
          arec.isindiantribe          =     rec.isindiantribe;
          arec.isintermunicipallocalgovernment      =         rec.isintermunicipallocalgovernment;
          arec.isinternationalorganization         =      rec.isinternationalorganization;
          arec.islaborsurplusareafirm          =     rec.islaborsurplusareafirm;
          arec.islocalgovernmentowned           =    rec.islocalgovernmentowned;
          arec.ismunicipalitylocalgovernment     =          rec.ismunicipalitylocalgovernment;
          arec.isnativehawaiianownedorganizationorfirm       =        rec.isnativehawaiianownedorganizationorfirm;
          arec.isotherbusinessororganization          =     rec.isotherbusinessororganization;
          arec.isotherminorityowned        =       rec.isotherminorityowned;
          arec.ispartnershiporlimitedliabilitypartnership   =            rec.ispartnershiporlimitedliabilitypartnership;
          arec.isschooldistrictlocalgovernment      =         rec.isschooldistrictlocalgovernment;
          arec.issmallagriculturalcooperative        =       rec.issmallagriculturalcooperative;
          arec.issoleproprietorship         =      rec.issoleproprietorship;
          arec.istownshiplocalgovernment     =          rec.istownshiplocalgovernment;
          arec.istriballyownedfirm           =    rec.istriballyownedfirm;
          arec.istribalcollege          =     rec.istribalcollege;
          arec.isalaskannativeownedcorporationorfirm    =           rec.isalaskannativeownedcorporationorfirm;
          arec.iscorporateentitytaxexempt        =       rec.iscorporateentitytaxexempt;
          arec.iswomenownedsmallbusiness          =     rec.iswomenownedsmallbusiness;
          arec.isecondisadvwomenownedsmallbusiness     =          rec.isecondisadvwomenownedsmallbusiness;
          arec.isjointventurewomenownedsmallbusiness    =           rec.isjointventurewomenownedsmallbusiness;
          arec.isjointventureecondisadvwomenownedsmallbusiness     =          rec.isjointventureecondisadvwomenownedsmallbusiness;
          arec.walshhealyact         =      rec.walshhealyact;
          arec.servicecontractact     =          rec.servicecontractact;
          arec.davisbaconact          =     rec.davisbaconact;
          arec.clingercohenact        =       rec.clingercohenact;
          arec.otherstatutoryauthority    =           rec.otherstatutoryauthority;
          arec.prime_awardee_executive1    =           rec.prime_awardee_executive1;
          arec.prime_awardee_executive1_compensation       =        rec.prime_awardee_executive1_compensation;
          arec.prime_awardee_executive2          =     rec.prime_awardee_executive2;
          arec.prime_awardee_executive2_compensation     =          rec.prime_awardee_executive2_compensation;
          arec.prime_awardee_executive3       =        rec.prime_awardee_executive3;
          arec.prime_awardee_executive3_compensation       =        rec.prime_awardee_executive3_compensation;
          arec.prime_awardee_executive4         =      rec.prime_awardee_executive4;
          arec.prime_awardee_executive4_compensation     =          rec.prime_awardee_executive4_compensation;
          arec.prime_awardee_executive5       =        rec.prime_awardee_executive5;
          arec.prime_awardee_executive5_compensation      =         rec.prime_awardee_executive5_compensation;
          arec.interagencycontractingauthority      =         rec.interagencycontractingauthority;
          arec.last_modified_date    =           rec.last_modified_date;
            if (rec.contract_vehicle == null)
                arec.contract_vehicle= String.Empty;
            else
            {
                arec.contract_vehicle= rec.contract_vehicle;
            }
            if (rec.work == null)

                arec.work =  String.Empty;
            else
            {
                arec.work= rec.work;
            }
            if (rec.completion_date == null)
                arec.completion_date = null;
            else
            {
              arec.completion_date = rec.completion_date;
            }
            if (rec.completion_year == null)

                arec.completion_year = String.Empty;
            else
            {
             arec.completion_year = rec.completion_year;
            }
            // "\"" +  rec.contract_vehicle.ToString() + "\""  +  "," +
            // "\"" +  rec.work.ToString() + "\""  +  "," +
            // "\"" +  rec.completion_date.ToString() + "\""  +  "," +
            // "\"" +  rec.completion_year.ToString() + "\""  +  "," +
           arec.insert_date= rec.insert_date;
             arec.insert_user= rec.insert_user;
             return arec;
        }
    }
}
