import wepy from 'wepy'

export default class testMixin extends wepy.mixin {
  data = {
    mixin: 'This is mixin data.',
    countryFields: { 
      ke: {
        passport_file:1, photo_file:1, id_front_file:1,
        nationality_cn:1, name_cn:1, name:1, sex:1, birth_date:1, birth_place_cn:1, birth_place:1,
        job_type:1, job_comp_cn:1, job_comp:1, job_title_cn:1, job_title:1,
        passport_no:1, authority:1, issue_place_cn:1, issue_place:1, issue_date:1, expiry_date:1,
        father_name:1, mother_name:1, region:1, address_cn:1, address:1, phone:1, email:1,
        purpose:1, entry_date:1, departure_date:1, by:1,
        return_to_domicile:1, been_other_country:1, ever_been_to:1, ever_denied:1,
        ever_denied_by_other:1, ever_convicted:1
      }
    }
  }
  methods = {
    tap () {
      this.mixin = 'mixin data was changed'
      console.log('mixin method tap')
    }
  }

  getFieldNames(country) {
    return this.countryFields[country]
  }

  onShow() {
    console.log('mixin onShow')
  }

  onLoad() {
    console.log('mixin onLoad')
  }
}
