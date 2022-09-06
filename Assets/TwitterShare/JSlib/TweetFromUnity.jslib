mergeInto(LibraryManager.library, {
  CallbackHandlerControl: function (rawMessage, url) {
    var message = UTF8ToString(rawMessage);
    var proxyURL = UTF8ToString(url);
  
    if (window.location.href.includes("?oauth")) {
      var str = window.location.href;
      str = str.split("?").pop();

      var clientOauth = "";
      var clientSecretOauth = "";


      var resultObject = {};
      var tokens = str.split('&');
      for (let index = 0; index < tokens.length; index++) {
        const token = tokens[index];
        var [key, content] = token.split('=');
        resultObject[key] = content;
      }
      var raw = JSON.stringify({
        "oauth_token": resultObject.oauth_token,
        "oauth_verifier": resultObject.oauth_verifier
      });



      var myHeaders = new Headers();
      myHeaders.append("Content-Type", "application/json");
      var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: raw,
        redirect: 'follow'
      };

      fetch(proxyURL + "/oauth/access_token", requestOptions)
        .then(response => response.text())
        .then(result => {
          var resultStr = result;
          var ClientKeyObject = {};
          var ClientTokens = resultStr.split('&');
          for (let index = 0; index < ClientTokens.length; index++) {
            const ClientToken = ClientTokens[index];
            var [key, content] = ClientToken.split('=');
            ClientKeyObject[key] = content;
          }


          var targetUrl = proxyURL + "/1.1/media/upload.json";


          var raw = JSON.stringify({
            "oauth_token": ClientKeyObject.oauth_token,
            "media_data": localStorage.getItem("pino_media_base64"),
            "oauth_token_secret": ClientKeyObject.oauth_token_secret
          });
          var myHeaders = new Headers();
          myHeaders.append("Content-Type", "application/json");
          var requestOptions = {
            method: 'POST',
            body: raw,
            headers: myHeaders,
            redirect: 'follow'
          };
          fetch(targetUrl, requestOptions)
            .then(response => response.text())
            .then(result => {
              
		localStorage.removeItem("pino_media_base64");
              localStorage.removeItem("pino_media_id");
              localStorage.setItem("pino_media_id", JSON.parse(result).media_id_string);


              var raw = JSON.stringify({
                "text": message,
                "media": {
                  "media_ids": [
                    localStorage.getItem("pino_media_id")
                  ]
                },
                "oauth_token": ClientKeyObject.oauth_token,
                "oauth_token_secret": ClientKeyObject.oauth_token_secret

              });


              var Options = {
                method: 'POST',
                headers: {
                  "Content-Type": "application/json",
                },
                body: raw,
                redirect: 'follow'
              };


              fetch(proxyURL + "/2/tweets", Options)
                .then(response => {if(response.status == 200){
                  alert("Share completed!");
                } })
                .then(result =>{
                  localStorage.removeItem("pino_media_id");
                  console.log(result);
                } )
                .catch(error => console.log('error', error));



            })




            .catch(error => console.log('error', error));

        })
        .catch(error => console.log('error', error));

    }

  },


SaveScreenCapture: function (media_base64) {
media_base64 = UTF8ToString(media_base64);
localStorage.removeItem("pino_media_id");
localStorage.setItem("pino_media_id",media_base64);
    },



  GetURLCallBack: function()
{

if(window.location.href.includes("?oauth")){
  var returnStr = window.location.href.split("?")[0];
}else{
  var returnStr = window.location.href;
};

var bufferSize = lengthBytesUTF8(returnStr) + 1
var buffer = _malloc(bufferSize);
stringToUTF8(returnStr, buffer, bufferSize);
return buffer;
},


  Redirect: function (rawURL) {
        var url= UTF8ToString(rawURL);

	var mobilePattern = /android|iphone|ipad|ipod/i;
        var ua = window.navigator.userAgent.toLowerCase();

        if (ua.search(mobilePattern) !== -1 || (ua.indexOf("macintosh") !== -1 && "ontouchend" in document)) {
            // Mobile
            window.location.assign(url);
        } else {
            // PC
            window.open(url);
        }
    },



  SaveMediaBase64: function(mediaBase64)
{
mediaBase64= UTF8ToString(mediaBase64);
localStorage.removeItem("pino_media_base64");
    localStorage.setItem("pino_media_base64",mediaBase64);
},


GetURL: function()
{
return window.location.href;
},

 TweetWithUnity: function(rawMessage)
{

},








});
