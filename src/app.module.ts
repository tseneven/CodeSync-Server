import { Module } from '@nestjs/common';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { MainusersModule } from './mainusers/mainusers.module';

@Module({
  imports: [MainusersModule],
  controllers: [AppController],
  providers: [AppService],
})
export class AppModule {}
