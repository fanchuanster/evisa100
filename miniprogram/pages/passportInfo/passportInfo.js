// miniprogram/pages/passportInfo/passportInfo.details.js
const app = getApp()
Page({

  /**
   * Page initial data
   */
  data: {
    passportInfo:null
  },

  /**
   * Lifecycle function--Called when page load
   */
  onLoad: function (options) {
    this.setData({
      passportInfo : wx.getStorageSync('passportInfo')
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
      ['passportInfo.details.passport_no']: e.detail.value
    })
  },
  inputPassportcountry: function (e) {
    this.setData({
      ['passportInfo.details.nationality']: e.detail.value
    })
  },

  inputPassporttype: function (e) {
    this.setData({
      ['passportInfo.details.type']: e.detail.value
    })
  },

  inputPassportname_cn: function (e) {
    this.setData({
      ['passportInfo.details.name_cn']: e.detail.value
    })
  },
  inputPassportname: function (e) {
    this.setData({
      ['passportInfo.details.name']: e.detail.value
    })
  },
  inputPassportinputPassportsextype: function (e) {
    this.setData({
      ['passportInfo.details.sex']: e.detail.value
    })
  },
  inputPassportbirth_date: function (e) {
    this.setData({
      ['passportInfo.details.birth_date']: e.detail.value
    })
  },
  inputPassportbirth_place: function (e) {
    this.setData({
      ['passportInfo.details.birth_place']: e.detail.value
    })
  },

  inputPassportauthority: function (e) {
    this.setData({
      ['passportInfo.details.authority']: e.detail.value
    })
  },
  inputPassportissue_date: function (e) {
    this.setData({
      ['passportInfo.details.issue_date']: e.detail.value
    })
  },
  inputPassportexpiry_date: function (e) {
    this.setData({
      ['passportInfo.details.expiry_date']: e.detail.value
    })
  },
  inputPassportissue_place: function (e) {
    this.setData({
      ['passportInfo.details.issue_place']: e.detail.value
    })
  },
  
  /**
   * Lifecycle function--Called when page hide
   */
  onHide: function () {
    wx.setStorageSync('passportInfo', this.data.passportInfo)
  },

  nextToUploadPhoto: function() {
    var that = this
    wx.request({
      url: 'https://fan.blockai.me/save_passport.php',
      data: this.data.passportInfo,
      method: 'POST',
      header: {
        'content-type': 'application/json; charset=UTF-8'
      },
      success: function (res) {
        console.log(res)
        that.data.passportInfo.id = res.data.id
        wx.navigateTo({
          url: '../photo/photo',
        })
      },
      error: function (res) {
        console.log(res.err)
      }
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