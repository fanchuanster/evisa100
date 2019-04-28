var config = {
  //aliyun OSS config
  ossHost: 'https://evisa.oss-cn-shanghai.aliyuncs.com',
  accesskey: 'NyNOmcGHgyKX5vHUtn9lv7M1vCJWL3',
  accessid: 'LTAIQMDDOG5SOtsh',
  timeout: 87600, // policy valid timespan.
  adminOpenid: 'opini5GNX-N6JKq6aqutfPHCxUDc',
  countryFields: {
    all: {
      passport_file:1, photo_file:1, other_file:0, id_front_file:0,
      country_cn:1, name_cn:1, name:1, sex:1, marital_status:1, birth_date:1, birth_place_cn:1, birth_place:1,
      job_type:1, job_comp_cn:0, job_comp:0, job_title_cn:1, job_title:1,
      passport_no:1, authority:1, issue_place:1, issue_date:1, expiry_date:1,
      father_name:1, father_name_cn:1, mother_name:1, mother_name_cn:1, region:1, address_cn:1, address:1, phone:1, email:1,
      purpose:1, entry_date:1, departure_date:1, by:1, entry_point:1,
      return_to_domicile:1, been_other_country:1, ever_been_to:1, ever_denied:1,
      ever_denied_by_other:1, ever_convicted:1, destination: 1
    },
    ke: {
      passport_file:1, photo_file:1, other_file:0, id_front_file:1,
      country_cn:0, name_cn:1, name:1, sex:1, birth_date:1, birth_place_cn:1, birth_place:1,
      job_type:1, job_comp_cn:0, job_comp:0, job_title_cn:1, job_title:1,
      passport_no:1, authority:1, issue_place:1, issue_date:1, expiry_date:1,
      father_name:1, mother_name:1, region:1, address_cn:1, address:1, phone:1, email:1,
      purpose:1, entry_date:1, departure_date:1, by:1, entry_point:1,
      return_to_domicile:1, been_other_country:1, ever_been_to:1, ever_denied:1,
      ever_denied_by_other:1, ever_convicted:1
    },
    tl: {
      passport_file:1, photo_file:1,
      country_cn:0, name_cn:1, name:1, sex:1, marital_status:1, birth_date:1, birth_place_cn:1, birth_place:1,
      job_type:1, job_comp_cn:0, job_comp:0, job_title_cn:1, job_title:1,
      passport_no:1, authority:1, issue_place:1, issue_date:1, expiry_date:1,
      father_name:1, mother_name:1, region:1, address_cn:1, address:1, phone:1, email:1,
      purpose:1, entry_date:1, departure_date:1, by:1,
      ever_been_to:1, destination: 1
    },
    zm: {
      passport_file:1, photo_file:1,
      country_cn:0, name_cn:1, name:1, sex:1, marital_status:1, birth_date:1, birth_place_cn:1, birth_place:1,
      job_type:1, job_comp_cn:0, job_comp:0, job_title_cn:1, job_title:1,
      passport_no:1, authority:1, issue_place:1, issue_date:1, expiry_date:1,
      father_name:1, mother_name:1, region:1, address_cn:1, address:1, phone:1, email:1,
      purpose:1, entry_date:1, departure_date:1, by:1,
      ever_been_to:1, destination: 1
    },
    tz: {
      passport_file:1, photo_file:1,
      country_cn:0, name_cn:1, name:1, sex:1, marital_status:1, birth_date:1, birth_place_cn:1, birth_place:1,
      job_type:1, job_comp_cn:0, job_comp:0, job_title_cn:1, job_title:1,
      passport_no:1, authority:1, issue_place:1, issue_date:1, expiry_date:1,
      father_name:1, mother_name:1, region:1, address_cn:1, address:1, phone:1, email:1,
      purpose:1, entry_date:1, departure_date:1, by:1,
      ever_been_to:1, destination: 1
    }
  },

  entrypoints: {
    ke: [[
        { name_cn: '埃尔多雷特国际机场', name: 'Eldoret International Airport' },
        { name_cn: '加里萨机场', name: 'Garisa Airstrip' },
        { name_cn: '乔莫·肯雅塔国际机场', name: 'Jomo Kenyatta Airport, Nairobi' },
        { name_cn: '基苏木机场', name: 'Kisumu Airport' },
        { name_cn: '拉木机场', name: 'Lamu Airport' },
        { name_cn: '洛基基奥机场', name: 'Lokichogio Airport' },
        { name_cn: '马林迪机场', name: 'Malindi Airport' },
        { name_cn: '蒙巴萨莫伊机场', name: 'Moi Airport Mombasa' },
        { name_cn: '瓦吉尔国际机场', name: 'Wajir International Airport' },
        { name_cn: '内罗毕威尔逊机场', name: 'Wilson Airport, Nairobi' }],
      [
        { name_cn: '布西亚', name: 'Busia' },
        { name_cn: '伊塞巴尼亚', name: 'Isebania' },
        { name_cn: 'Liboi', name: 'Liboi' },
        { name_cn: 'Loitokitok', name: 'Loitokitok' },
        { name_cn: 'Lungalunga', name: 'Lungalunga' },
        { name_cn: 'Malaba', name: 'Malaba' },
        { name_cn: 'Mandera', name: 'Mandera' },
        { name_cn: 'Moyale', name: 'Moyale' },
        { name_cn: 'Nadapal', name: 'Nadapal' },
        { name_cn: 'Namanga', name: 'Namanga' },
        { name_cn: 'Taveta', name: 'Taveta' }],
      [
        { name_cn: '启林迪尼', name: 'Kilindini' },
        { name_cn: '基苏木', name: 'Kisumu' },
        { name_cn: 'Kuinga', name: 'Kuinga' },
        { name_cn: '拉穆', name: 'Lamu' },
        { name_cn: '马林迪', name: 'Malindi' },
        { name_cn: '姆比塔点', name: 'Mbita Point' },
        { name_cn: 'Muhuru Bay', name: 'Muhuru Bay' },
        { name_cn: '老港', name: 'Old Port' },
        { name_cn: '希莫尼', name: 'Shimoni' },
        { name_cn: '万加', name: 'Vanga' }]],

    destinations: {
      tz: []
    }
  }
};

(function(){

  
  config.getFields = function(country) {
    return this.countryFields[country]
  };
  config.getEntryPoints = function(country) {
    return this.entrypoints[country]
  };
  config.getDestinations = function(country) {
    return this.destinations[country]
  };

})();

module.exports = config
