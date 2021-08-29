<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:template match="/">
        <html>
            <head>
                <title></title>
                <!-- Latest compiled and minified CSS -->
                <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" integrity="sha384-HSMxcRTRxnN+Bdg0JdbxYKrThecOKuH5zCYotlSAcp1+c8xmyTe9GYg1l9a69psu" crossorigin="anonymous" > </link>
            </head>
            <body>
                <div style="text-align: center;">
                    <big>
                        <big>
                            <big>
                                <big>
                                    <xsl:value-of select="/data/person/FirstName"/>
                                </big>
                            </big>
                        </big>
                    </big>
                    <br/>Phone/email/skype
                    <br/>
                </div>
                <br />
                <div>
                    <xsl:for-each select="/data/workhistory">
                        <div>
                            <label  type="text"   placeholder="Organisation" >
                                <xsl:value-of select="Organisation"/>
                            </label>
                        </div>
                        <div class="form-group col-sm-5">
                            <label  type="text"  placeholder="Location"  >
                                <xsl:value-of select="Location"/>
                            </label>
                        </div>
                        <div >
                            <div class="form-group col-sm-4">
                                <label  type="text"   placeholder="Position"  >
                                    <xsl:value-of select="Position"/>
                                </label>
                            </div>
                            <div class="form-group col-sm-1">
                                <label>From</label>
                            </div>
                            <div class="form-group col-sm-1">
                                <label  style="width:60px;" name="wrk.MonthCompletedFrom" type="text"  placeholder="MM" >
                                    <xsl:value-of select="PosiMonthCompletedFromtion"/>
                                </label>
                            </div>
                            <div class="form-group col-sm-2">
                                <label style="width:90px;" name="wrk.YearCompletedFrom" type="text"  placeholder="YYYY" >
                                    <xsl:value-of select="YearCompletedFrom"/>
                                </label>
                            </div>
                            <div class="form-group col-sm-1">
                                <label>To</label>
                            </div>
                            <div class="col-sm-1">
                                <label  style="width:60px;" name="wrk.MonthCompletedTo" type="text" placeholder="MM" >
                                  <xsl:value-of select="MonthCompletedTo"/>
                                  </label>
                            </div>
                            <div class="col-sm-2">
                                <label  style="width:90px;" name="wrk.YearCompletedTo" type="text"     placeholder="YYYY" >
                                  <xsl:value-of select="YearCompletedTo"/>
                                  </label>
                            </div>
                        </div>
                        <div >
                            <div class="form-group col-sm">
                                <label type="text"  placeholder="Decription" ></label>
                            </div>
                        </div>
                        <div >
                            <div class="form-group col-sm">
                                <label >Roles and Responsibilites</label>
                                <textarea  type="date" rows="7"   ></textarea>
                            </div>
                        </div>
                    </xsl:for-each>
                </div>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>