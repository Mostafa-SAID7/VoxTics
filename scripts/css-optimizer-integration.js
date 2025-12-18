/**
 * VoxTics CSS Optimizer - ASP.NET Core Integration
 * Performance optimizations and build pipeline integration
 */

const { spawn } = require('child_process');
const { FileSystemUtils, PerformanceUtils } = require('./css-optimizer-utils');

/**
 * ASP.NET Core build integration
 */
class AspNetCoreIntegration {
  constructor(projectPath = 'VoxTics') {
    this.projectPath = projectPath;
    this.bundleConfigPath = `${projectPath}/bundleconfig.json`;
    this.webConfigPath = `${projectPath}/web.config`;
  }

  async integrateCSSOptimization() {
    console.log('🔧 Integrating CSS optimization with ASP.NET Core...');
    
    await Promise.all([
      this.updateBundleConfig(),
      this.createBuildTargets(),
      this.setupCaching(),
      this.configureCompression()
    ]);
    
    console.log('✅ ASP.NET Core integration complete');
  }

  async updateBundleConfig() {
    const bundleConfig = {
      "outputFileName": "wwwroot/css/voxtics-optimized.min.css",
      "inputFiles": [
        "wwwroot/css/optimized/voxtics-consolidated.css",
        "wwwroot/css/optimized/shared.css",
        "wwwroot/css/optimized/movies.css",
        "wwwroot/css/optimized/cinemas.css",
        "wwwroot/css/optimized/bookings.css"
      ],
      "minify": {
        "enabled": true,
        "renameLocals": true,
        "commentType": "none"
      }
    };

    await FileSystemUtils.safeWriteFile(
      this.bundleConfigPath, 
      JSON.stringify([bundleConfig], null, 2)
    );
  }

  async createBuildTargets() {
    const buildTargets = `
<Project>
  <Target Name="OptimizeCSS" BeforeTargets="Build">
    <Message Text="Running VoxTics CSS Optimization..." Importance="high" />
    <Exec Command="node scripts/css-optimizer-improved.js" 
          ContinueOnError="false" 
          WorkingDirectory="$(MSBuildProjectDirectory)/.." />
  </Target>
  
  <Target Name="BundleCSS" AfterTargets="OptimizeCSS">
    <Message Text="Bundling optimized CSS..." Importance="high" />
    <Exec Command="dotnet bundle" 
          ContinueOnError="false" 
          WorkingDirectory="$(MSBuildProjectDirectory)" />
  </Target>
</Project>
`;

    await FileSystemUtils.safeWriteFile(
      `${this.projectPath}/VoxTics.Build.targets`,
      buildTargets
    );
  }

  async setupCaching() {
    const cacheConfig = `
// CSS Optimization Cache Configuration
public static class CSSCacheConfiguration
{
    public static void ConfigureCSS(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<StaticFileOptions>(options =>
        {
            options.OnPrepareResponse = ctx =>
            {
                var headers = ctx.Context.Response.Headers;
                
                // Cache CSS files for 1 year with versioning
                if (ctx.File.Name.EndsWith(".css"))
                {
                    headers.CacheControl = "public,max-age=31536000,immutable";
                    headers.ETag = GenerateETag(ctx.File);
                }
            };
        });
        
        // Enable response compression for CSS
        services.Configure<GzipCompressionProviderOptions>(options =>
        {
            options.Level = CompressionLevel.Optimal;
        });
        
        services.AddResponseCompression(options =>
        {
            options.EnableForHttps = true;
            options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                new[] { "text/css", "application/css" });
        });
    }
    
    private static string GenerateETag(IFileInfo file)
    {
        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(
            $"{file.Name}{file.Length}{file.LastModified}"));
        return Convert.ToBase64String(hash);
    }
}
`;

    await FileSystemUtils.safeWriteFile(
      `${this.projectPath}/Configuration/CSSCacheConfiguration.cs`,
      cacheConfig
    );
  }

  async configureCompression() {
    const compressionMiddleware = `
// Add to Program.cs or Startup.cs
app.UseResponseCompression();
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        // Set cache headers for CSS files
        if (ctx.File.Name.EndsWith(".css"))
        {
            ctx.Context.Response.Headers.CacheControl = "public,max-age=31536000";
        }
    }
});
`;

    console.log('📝 Add the following to your Program.cs:');
    console.log(compressionMiddleware);
  }
}

/**
 * Performance monitoring and optimization
 */
class PerformanceOptimizer {
  constructor() {
    this.metrics = {
      fileProcessingTimes: [],
      memoryUsage: [],
      cssRulesCounts: [],
      optimizationResults: []
    };
  }

  async optimizeWithMonitoring(optimizer) {
    const overallTimer = PerformanceUtils.startTimer('Overall Optimization');
    
    try {
      // Monitor memory usage
      this.startMemoryMonitoring();
      
      // Run optimization with performance tracking
      const result = await this.runOptimizationStages(optimizer);
      
      // Stop monitoring
      this.stopMemoryMonitoring();
      
      // Generate performance report
      const performanceReport = this.generatePerformanceReport(overallTimer.end());
      
      return { ...result, performance: performanceReport };
    } catch (error) {
      console.error('❌ Performance optimization failed:', error.message);
      throw error;
    }
  }

  async runOptimizationStages(optimizer) {
    const stages = [
      { name: 'File Scanning', method: 'scanFiles' },
      { name: 'CSS Parsing', method: 'parseCSS' },
      { name: 'Duplicate Detection', method: 'detectDuplicates' },
      { name: 'Usage Analysis', method: 'analyzeUsage' },
      { name: 'Structure Generation', method: 'generateStructure' },
      { name: 'Report Generation', method: 'generateReport' }
    ];

    const results = {};
    
    for (const stage of stages) {
      const timer = PerformanceUtils.startTimer(stage.name);
      
      try {
        console.log(`🔄 ${stage.name}...`);
        
        if (typeof optimizer[stage.method] === 'function') {
          results[stage.method] = await optimizer[stage.method]();
        }
        
        const timing = timer.end();
        this.metrics.fileProcessingTimes.push(timing);
        
        console.log(`✅ ${stage.name} completed in ${PerformanceUtils.formatDuration(timing.duration)}`);
      } catch (error) {
        console.error(`❌ ${stage.name} failed:`, error.message);
        throw error;
      }
    }
    
    return results;
  }

  startMemoryMonitoring() {
    this.memoryInterval = setInterval(() => {
      const usage = process.memoryUsage();
      this.metrics.memoryUsage.push({
        timestamp: Date.now(),
        heapUsed: usage.heapUsed,
        heapTotal: usage.heapTotal,
        external: usage.external,
        rss: usage.rss
      });
    }, 1000);
  }

  stopMemoryMonitoring() {
    if (this.memoryInterval) {
      clearInterval(this.memoryInterval);
    }
  }

  generatePerformanceReport(overallTiming) {
    const totalMemoryUsed = Math.max(...this.metrics.memoryUsage.map(m => m.heapUsed));
    const avgProcessingTime = this.metrics.fileProcessingTimes.reduce((sum, t) => sum + t.duration, 0) / this.metrics.fileProcessingTimes.length;

    return {
      overallDuration: overallTiming.duration,
      formattedDuration: PerformanceUtils.formatDuration(overallTiming.duration),
      peakMemoryUsage: PerformanceUtils.formatFileSize(totalMemoryUsed),
      averageStageTime: PerformanceUtils.formatDuration(avgProcessingTime),
      stageTimings: this.metrics.fileProcessingTimes,
      memoryProfile: {
        peak: Math.max(...this.metrics.memoryUsage.map(m => m.heapUsed)),
        average: this.metrics.memoryUsage.reduce((sum, m) => sum + m.heapUsed, 0) / this.metrics.memoryUsage.length,
        samples: this.metrics.memoryUsage.length
      },
      recommendations: this.generatePerformanceRecommendations()
    };
  }

  generatePerformanceRecommendations() {
    const recommendations = [];
    
    const totalDuration = this.metrics.fileProcessingTimes.reduce((sum, t) => sum + t.duration, 0);
    const peakMemory = Math.max(...this.metrics.memoryUsage.map(m => m.heapUsed));
    
    if (totalDuration > 30000) { // 30 seconds
      recommendations.push('Consider implementing parallel processing for large CSS files');
      recommendations.push('Add file size limits to prevent processing extremely large files');
    }
    
    if (peakMemory > 500 * 1024 * 1024) { // 500MB
      recommendations.push('Implement streaming processing for large files to reduce memory usage');
      recommendations.push('Add garbage collection hints for memory-intensive operations');
    }
    
    recommendations.push('Cache parsed CSS rules to avoid reprocessing unchanged files');
    recommendations.push('Implement incremental optimization for faster subsequent runs');
    
    return recommendations;
  }
}

/**
 * Build pipeline integration
 */
class BuildPipelineIntegration {
  static async setupNpmScripts() {
    const packageJsonPath = 'package.json';
    const packageJson = JSON.parse(await FileSystemUtils.safeReadFile(packageJsonPath) || '{}');
    
    // Add CSS optimization scripts
    packageJson.scripts = {
      ...packageJson.scripts,
      'optimize-css': 'node scripts/css-optimizer-improved.js',
      'optimize-css-watch': 'nodemon --watch VoxTics/wwwroot/css --watch VoxTics/Views --ext css,cshtml --exec "npm run optimize-css"',
      'build-optimized': 'npm run optimize-css && npm run build-css-prod',
      'dev-with-optimization': 'concurrently "npm run optimize-css-watch" "npm run build-css" "dotnet watch run --project VoxTics"'
    };
    
    await FileSystemUtils.safeWriteFile(packageJsonPath, JSON.stringify(packageJson, null, 2));
    console.log('✅ Updated package.json with CSS optimization scripts');
  }

  static async setupWebpackIntegration() {
    const webpackConfigPath = 'webpack.config.js';
    const webpackConfig = await FileSystemUtils.safeReadFile(webpackConfigPath);
    
    if (webpackConfig) {
      const optimizationPlugin = `
// Add to webpack plugins array
new (class CSSOptimizationPlugin {
  apply(compiler) {
    compiler.hooks.beforeCompile.tapAsync('CSSOptimizationPlugin', (params, };egration
ntServerIntvelopmeDe,
  ongratipelineIntedPi
  Builizer,nceOptim
  Performaon,oreIntegratietC= {
  AspNrts ule.expo
}

moded');
  }pt creatscriwatcher file ('✅ CSS console.log);
    tcherScripther.js', wa/css-watcts'scripteFile(s.safeWriilileSystemUt F    await');
`;

her startedtcCSS file wasole.log('✅ ;

con0);
}) 100    }
  },ssage);
r.merroled:', eation faitimizSS op('❌ Crrornsole.eco) {
      catch (error    } leted');
ion compimizat('✅ CSS optonsole.log);
      c.optimize(optimizert ai
      awzer();miOptiTicsCSSox = new Verst optimiz   con..');
   ion.S optimizat Running CSole.log('🎨      cons {
 try=> {
   () (async imeoutmeout = setTtimizationTi
  oponTimeout);tiut(optimizaclearTimeon
  izatio optimnce
  // Debou;
  \${path}\`)ged: le chan(\`📝 Filog
  console.h) => {, (paton('change'

watcher.Timeout;mization

let optiue
});stent: trj/,
  persi|bin|obmodulesde_red: /no, {
  ignoml'
]*.cshteas/**/'VoxTics/Artml',
  ws/**/*.cshTics/Viess',
  'Voxcss/**/*.ccs/wwwroot/[
  'VoxTiwatch( = chokidar.watchert 
cons);
er...' file watching CSStart'🔍 Se.log(

consol');-improvedoptimizers-('./cs } = requireersCSSOptimiz VoxTic
const {chokidar');quire('r = rest chokidat = `
concherScriponst wat
    ccher() {FileWatnc setupc asy
  stati
  }
fig);oneloadCe.log(hotRconsol  ;
   reload:')SS hot for C.csProgramyour owing to foll('📝 Add the console.log
`;

    Async();
}itss.WaitForExocepr   await tart();
 ocess.S    
    pr  };
      }
  = true
  Window eNo    Creat,
        utput = truerdOrectStanda     Redi,
       te = falseellExecu       UseSh
     roved.js",er-impimizipts/css-opt"scrments =  Argu        ",
   odeName = "n File       
    
        {oartInfsStnew ProcesInfo = rt      Sta
  
    {essroc= new Pss   var proce  )
{
ation(timizriggerCSSOp Task Tstatic asyncprivate 

});
}  t();
   await nex           
           }
 urn;
     ret
        200;sCode =tuesponse.Sta   context.R
         n();SOptimizatioit TriggerCS        awaon
    zatitimireop CSS / Trigger    / {
           )
    SS-Reload")("X-C.ContainsKey.HeadersRequestxt.  conte           && 
"/css")ents(hSegmtsWitth.Starquest.Paxt.Rente     if (co{
   ) =>
    ontext, next(async (cp.Use    apleware
load midd CSS hot re   //())
{
 velopmentDeonment.Isp.Envir (apent
ift environmvelopmencs in deogram.// Add to Prg = `
nfiCo hotReload    constReload() {
tupHot sestatic async
  on {tierIntegraServvelopment
class De */ation
ntegrver i serntopmevel
/**
 * De
  }
}
);installed'ook -commit h Git pre('✅ole.logons
    c }
    it');
   -commpreoks/ho +x .git/hmod'cc(;
      execess')d_prouire('chilxec } = req{ eonst {
      cwin32') atform !== 'rocess.pl (p   ifx systems
 n Uniecutable oex  // Make 
    
  );reCommitHookommit', phooks/pre-cile('.git/WriteFs.safetemUtil FileSysit  awa`;

  exit 1
fi
   failed"
imizationptCSS ocho "❌ 
else
  e/edizptim/css/os/wwwrootadd VoxTict ully"
  giccessfpleted suation com optimiz✅ CSS"en
  echo ]; th [ $? -eq 0 e-css

ifptimiz"
npm run oation...izoptiming CSS ho "🎨 RunnHook

ecmit n Pre-comizatios CSS Optim
# VoxTicsh/bin/`#!ook =  preCommitH
    constooks() {GitHup async setstatic }

     }
 n);
 ationPlugilog(optimize.      consol');
fig.js:ebpack.con your wtoin llowing plug fod the📝 Adlog('console.    
      ;
  
` }
})()
 ;
    });
      })       });
 ailed') fmizationptiror('CSS ock(new Erallba c
             } else {
    lback();       cal);
   ed' completonoptimizati('✅ CSS le.logconso          0) {
===    if (code    ) => {
  code', (.on('closeizerptim  
      o   });
    
   rit' 'inhe      stdio:s'], {
  proved.jims-optimizer-pts/cs['scride', nor = spawn('st optimize con');
     essld_proce('chiirquspawn } = reonst {      cck) => {
 llbaca