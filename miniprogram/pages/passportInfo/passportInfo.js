// miniprogram/pages/passportInfo/passportInfo.js
const app = getApp()
Page({

  /**
   * Page initial data
   */
  data: {
    passport_no:'',
    country: '',
    type:'',

    name_cn:'',
    name:'',
    sex:'',
    birth_date: '',

    birth_place:'',
    birth_place_raw:'',
    issue_date:'',
    issue_place:'',
    issue_place_raw:'',
    expiry_date:'',

    authority: '',

    person_id:'',

    line0:'',
    line1:'',
    success:''
  },

  /**
   * Lifecycle function--Called when page load
   */
  onLoad: function (options) {
    this.setData({
      passport_no: app.globalData.passportInfo.passport_no,
      country: app.globalData.passportInfo.country,

      type: app.globalData.passportInfo.type,
      name_cn: app.globalData.passportInfo.name_cn,
      name: app.globalData.passportInfo.name,
      sex: app.globalData.passportInfo.sex,
      birth_date: app.globalData.passportInfo.birth_date,
      birth_place: app.globalData.passportInfo.birth_place,
      birth_place_raw: app.globalData.passportInfo.birth_place_raw,
      issue_date: app.globalData.passportInfo.issue_date,
      issue_place: app.globalData.passportInfo.issue_place,
      issue_place_raw: app.globalData.passportInfo.issue_place_raw,
      expiry_date: app.globalData.passportInfo.expiry_date,
      authority: app.globalData.passportInfo.authority,

      person_id: app.globalData.passportInfo.person_id,
      birth_date: app.globalData.passportInfo.birth_date,
      success: app.globalData.passportInfo.success      
    })
  },

  /**
   * Lifecycle function--Called when page is initially rendered
   */
  onReady: function () {

  },

  /**
   * Lifecycle function--Called when page show
   */
  onShow: function () {

  },

  /**
   * Lifecycle function--Called when page hide
   */
  onHide: function () {

  },

  /**
   * Lifecycle function--Called when page unload
   */
  onUnload: function () {

  },

  /**
   * Page event handler function--Called when user drop down
   */
  onPullDownRefresh: function () {

  },

  /**
   * Called when page reach bottom
   */
  onReachBottom: function () {

  },

  /**
   * Called when user click on the top right corner to share
   */
  onShareAppMessage: function () {

  }
})