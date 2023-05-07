# 2D-PLATFORMER-PROJECT

a platform game, which is a genre of video games that involve guiding a character through a series of levels while jumping, running, and dodging obstacles. The player controls the character and must navigate through various challenges and puzzles to progress through the game.
## Feature

This game has 02 main modes:
- Levels
 
The levels will include players and obstacles. Players need to find a way to pass obstacles and monsters to reach the destination (may add a requirement to collect enough items or keys lock, or kill all monsters, .. depending on the game screen)
- Alive

Players need to survive as long as possible (or eat as many items as possible?) while the
Obstacles and monsters spawn more and more with increasing difficulty until the player dies
(the game ends)


Furthermore, this game will allow user to play with different characters. Each character will have different attributes (movement speed, ..) & special abilities (double jump, dash, ... 


## Technology

Framework/Game Engine: Unity (C#)

Applying the [CI/CD](https://game.ci) approach to development: Github Action and GameCI

The Unity development environment itself has enough capabilities to manage & encapsulate dependencies.


## Deployment
- Using the Game Action and Game CI 
- In this project , create the folder workflows with the [link](project_root/.github/workflows).

### Unity license for Github Action's workflow test and build operation

Initialization Unity license for project workflows ( Obligatory )
- Create [activation.yml](.github/workflows/activation.yml)
- Config [activation.yml](.github/workflows/activation.yml)

```
name: Get Unity license activation file 🔐 
on: workflow_dispatch 
jobs: 
requestManualActivationFile: 
   name: Request manual activation file 🔑 
   runs-on: ubuntu-latest 
    steps: 
     - uses: actions/checkout@v2 
     - uses: game-ci/unity-request-activation-file@v2 
       id: getManualLicenseFile 

     - uses: actions/upload-artifact@v2 
     with: 
       name: Manual Activation 
       File path: ${{ steps.getManualLicenseFile.outputs.filePath }}
```

- With  on: workflow_dispatch, it only run by manual
- After initialating [activation.yml](.github/workflows/activation.yml) and pushing successfully to repository, the workflow will appear on Action

### Config Workflow Initialization for automatic test part for branch changes
- Using the Unity - Test runner
- Create [config](.github/workflows/test_runner.yml)
- Config [test_runner.yml](.github/workflows/test_runner.yml)

```
name: Build project 
on:
   push:
     branches:
     - main 
     - 'dev/**'
     - 'releases/**' 
   pull_request:
     branches:
     - main 
     - 'releases/**' 

jobs: 
  testAllModes: 
    name: Test in ${{ matrix.testMode}} 
    runs-on: ubuntu-latest 
    strategy: 
      fail-fast: false 
      matrix: 
        projectPath: 
          - ${{ github.workspace }} 
        testMode: 
          - playmode 
          - editmode 
    steps: 
      - uses: actions/checkout@v2 
        with: 
          lfs: true 
      - uses: actions/cache@v2
        with: 
          path: Library key: Library-${{ matrix.projectPath }}/Library
          restore-keys: Library- 
      - uses: game-ci/unity-test-runner@v2 
        id: tests
        env:
          UNITY_LICENSE: ${{ secrets.UNITY_LICENSE }} 
        with: 
          projectPath: ${{ matrix.projectPath}}
          testMode:  ${{ matrix.testMode}}
          artifactsPath: ${{ matrix.testMode }}-artifacts
          checkName:  ${{ matrix.testMode }} Test Results
          coverageOptions: 'generateAdditionalMetrics;generateHtmlReport;generateBadgeReport;assemblyFilters:+my.assembly.*' - uses: actions/upload-artifact@v2
      - uses: actions/upload-artifact@v2 
        if: always()
        with: 
          name: Test results for ${{ matrix.testMode }} 
          path: ${{ steps.tests.outputs.artifactsPath }}
- uses: actions/upload-artifact@v2
      - uses: actions/upload-artifact@v2 
        if: always()
        with: 
          name:  Coverage results for ${{ matrix.testMode }} 
          path:  ${{ steps.tests.outputs.coveragePath }}
```
### Config Workflow Initialization for testing builded project 
- Using the Unity - Builder
- Create [config](.github/workflows/build_runner.yml)
- Config [build_runner.yml](.github/workflows/build_runner.yml)

```
name: Build project 
on:
   pull_request:
     branches:
     - main 
     - 'releases/**' 
jobs: 
  buildForAllSupportedPlatforms: 
    name: Build for ${{ matrix.targetPlatform }} 
    runs-on: ubuntu-latest 
    strategy: 
      fail-fast: false 
      matrix: 
        targetPlatform: 
          - StandaloneWindows64 # Build a Windows 64-bit standalone. 
          - iOS # Build an iOS player. 
          - Android # Build an Android .apk standalone app. 
    steps: 
      - uses: actions/checkout@v2 
        with: 
          fetch-depth: 0 
          lfs: true 
      - uses: actions/cache@v2
        with: 
          path: Library key: Library-${{ matrix.targetPlatform }}
          restore-keys: Library- 
      - uses: game-ci/unity-builder@v2 
        env:
          UNITY_LICENSE: ${{ secrets.UNITY_LICENSE }} 
        with: 
          targetPlatform: ${{ matrix.targetPlatform }}
      - uses: actions/upload-artifact@v2 
        with: 
          name: Build-${{ matrix.targetPlatform }} 
          path: build/${{ matrix.targetPlatform }}
```
- Note
```
on:
   pull_request:
     branches:
     - main 
     - 'releases/**'
```
