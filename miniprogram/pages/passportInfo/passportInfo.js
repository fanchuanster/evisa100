// miniprogram/pages/passportInfo/passportInfo.js
const app = getApp()
Page({

  /**
   * Page initial data
   */
  data: {
    passportInfo:null
    // passport_no:'',
    // country: '',
    // type:'',

    // name_cn:'',
    // name:'',
    // sex:'',
    // birth_date: '',

    // birth_place:'',
    // birth_place_raw:'',
    // issue_date:'',
    // issue_place:'',
    // issue_place_raw:'',
    // expiry_date:'',
    // authority: '',
    // person_id:'',

    // line0:'',
    // line1:'',
    // success:''
  },

  /**
   * Lifecycle function--Called when page load
   */
  onLoad: function (options) {
    this.setData({
      passportInfo : app.globalData.passportInfo
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

  inputPassportNo: function (e) {
    this.setData({
      ['passportInfo.passport_no']: e.detail.value
    })
  },
  inputPassportcountry: function (e) {
    this.setData({
      ['passportInfo.country']: e.detail.value
    })
  },

  inputPassporttype: function (e) {
    this.setData({
      ['passportInfo.type']: e.detail.value
    })
  },

  inputPassportname_cn: function (e) {
    this.setData({
      ['passportInfo.type']: e.detail.value
    })
  },
  inputPassportname: function (e) {
    this.setData({
      ['passportInfo.name']: e.detail.value
    })
  },
  inputPassportinputPassportsextype: function (e) {
    this.setData({
      ['passportInfo.sex']: e.detail.value
    })
  },
  inputPassportbirth_date: function (e) {
    this.setData({
      ['passportInfo.birth_date']: e.detail.value
    })
  },
  inputPassportbirth_place: function (e) {
    this.setData({
      ['passportInfo.birth_place']: e.detail.value
    })
  },

  inputPassportbirth_place_raw: function (e) {
    this.setData({
      ['passportInfo.birth_place_raw']: e.detail.value
    })
  },
  inputPassportauthority: function (e) {
    this.setData({
      ['passportInfo.authority']: e.detail.value
    })
  },
  inputPassportissue_date: function (e) {
    this.setData({
      ['passportInfo.issue_date']: e.detail.value
    })
  },
  inputPassportexpiry_date: function (e) {
    this.setData({
      ['passportInfo.expiry_date']: e.detail.value
    })
  },
  inputPassportissue_place: function (e) {
    this.setData({
      ['passportInfo.issue_place']: e.detail.value
    })
  },
  inputPassportissue_place_raw: function (e) {
    this.setData({
      ['passportInfo.issue_place_raw']: e.detail.value
    })
  },

  inputPassportissue_place_raw: function (e) {
    this.setData({
      ['passportInfo.issue_place_raw']: e.detail.value
    })
  },
  
  /**
   * Lifecycle function--Called when page hide
   */
  onHide: function () {
    console.log('passportinfo page hide')
  },

  nextToUploadPhoto: function() {
    wx.navigateTo({
      url: '../photo/photo',
    })
  },

  /**
   * Lifecycle function--Called when page unload
   */
  onUnload: function () {
    wx.setStorageSync('passportInfo', this.data.passportInfo)
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